using Newtonsoft.Json;
using RabbitMQ.Client.Events;
using System;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace YA.SassyMQ.Lib.RabbitMQ
{
    public partial class StandardPayload
    {

        private StandardPayload(SMQActorBase actor, string content, bool final)
        {
            this.PayloadId = Guid.NewGuid().ToString();

            this.Actor = actor;
            if (!ReferenceEquals(this.Actor, null))
            {
                this.SenderId = actor.SenderId.ToString();
                this.SenderName = actor.SenderName;
            }
            else
            {
                this.SenderId = Guid.NewGuid().ToString();
                this.SenderName = "Unnamed Actor";
            }

            this.Content = content;
        }

        public string PayloadId { get; set; }
        public string SenderId { get; set; }
        public string SenderName { get; set; }
        public string Content { get; set; }
        public string ErrorMessage { get; set; }
        public bool IsHandled { get; set; }
        public string DirectMessageQueue { get; set; }

        private SMQActorBase Actor { get; set; }
        private bool TimedOutWaiting { get; set; }
        private StandardPayload ReplyPayload { get; set; }
        private BasicDeliverEventArgs ReplyBDEA { get; set; }
        private bool ReplyRecieved { get; set; }
        
        public String ToJSON() 
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        private void HandleReplyTo(object sender, PayloadEventArgs e)
        {
            if (e.Payload.PayloadId == this.PayloadId)
            {
                this.ReplyPayload = e.Payload;
                this.ReplyBDEA = e.BasicDeliverEventArgs;
                this.ReplyRecieved = true;
            }
        }

        public Task WaitForReply(PayloadHandler payloadHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var waitTask = Task.Factory.StartNew(() =>
            {
                if (waitTimeout > 0 && !ReferenceEquals(payloadHandler, null))
                {
                    if (ReferenceEquals(this.Actor, null)) throw new Exception("Can't handle response if payload.Actor is null");

                    this.Actor.ReplyTo += this.HandleReplyTo;
                    try
                    {
                        this.TimedOutWaiting = false;
                        var startedAt = DateTime.Now;

                        while (!this.ReplyRecieved && !this.TimedOutWaiting && DateTime.Now < startedAt.AddSeconds(waitTimeout))
                        {
                            Thread.Sleep(100);
                        }
                    }
                    finally
                    {
                        this.Actor.ReplyTo -= this.HandleReplyTo;
                    }

                    if (!this.ReplyRecieved) this.TimedOutWaiting = true;

                    var errorMessageReceived = !ReferenceEquals(this.ReplyPayload, null) && !String.IsNullOrEmpty(this.ReplyPayload.ErrorMessage);

                    if (this.ReplyRecieved && !errorMessageReceived)
                    {
                        payloadHandler(this.ReplyPayload, this.ReplyBDEA);
                    }
                    else if (!ReferenceEquals(timeoutHandler, null)) timeoutHandler(this, default(BasicDeliverEventArgs));
                }
            });

            return waitTask;
        }

    }
}