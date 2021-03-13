using System;
using System.Linq;
using RabbitMQ.Client;
using System.Text;
using Newtonsoft.Json;
using RabbitMQ.Client.Events;
using System.Threading.Tasks;

namespace YA.SassyMQ.Lib.RabbitMQ
{
    public partial class SMQPerson : SMQActorBase
    {

        public SMQPerson(String amqpConnectionString)
            : base(amqpConnectionString, "person")
        {
        }

        protected override void CheckRouting(StandardPayload payload, BasicDeliverEventArgs  bdea)
        {
            try
            {
                switch (bdea.RoutingKey)
                {
                    
                    case "person.conversation.armediator.conversationrequested":
                        this.OnARMediatorConversationRequestedReceived(payload, bdea);
                        break;
                    
                    case "person.agreement.armediator.agreementrequested":
                        this.OnARMediatorAgreementRequestedReceived(payload, bdea);
                        break;
                    
                    case "person.chat.armediator.dmforyou":
                        this.OnARMediatorDMForYouReceived(payload, bdea);
                        break;
                    
                }

            }
            catch (Exception ex)
            {
                payload.ErrorMessage = ex.Message;
            }
            this.Reply(payload, bdea.BasicProperties.ReplyTo);
        }

        
        /// <summary>
        /// Responds to: ConversationRequested from ARMediator
        /// </summary>
        public event EventHandler<PayloadEventArgs> ARMediatorConversationRequestedReceived;
        protected virtual void OnARMediatorConversationRequestedReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.ARMediatorConversationRequestedReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.ARMediatorConversationRequestedReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: AgreementRequested from ARMediator
        /// </summary>
        public event EventHandler<PayloadEventArgs> ARMediatorAgreementRequestedReceived;
        protected virtual void OnARMediatorAgreementRequestedReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.ARMediatorAgreementRequestedReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.ARMediatorAgreementRequestedReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: DMForYou from ARMediator
        /// </summary>
        public event EventHandler<PayloadEventArgs> ARMediatorDMForYouReceived;
        protected virtual void OnARMediatorDMForYouReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.ARMediatorDMForYouReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.ARMediatorDMForYouReceived(this, plea);
            }
        }

        /// <summary>
        /// Hello - Hello
        /// </summary>
        public Task Hello(PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.Hello(this.CreatePayload(), replyHandler, timeoutHandler, waitTimeout);
        }    

        /// <summary>
        /// Hello - Hello
        /// </summary>
        public Task Hello(String content, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var payload = this.CreatePayload(content);
            return this.Hello(payload, replyHandler, timeoutHandler, waitTimeout);
        }

        /// <summary>
        /// Hello - Hello
        /// </summary>
        public Task Hello(StandardPayload payload, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SendMessage("armediator.general.person.hello", payload, replyHandler, timeoutHandler, waitTimeout);
        }
        /// <summary>
        /// SeePeople - SeePeople
        /// </summary>
        public Task SeePeople(PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SeePeople(this.CreatePayload(), replyHandler, timeoutHandler, waitTimeout);
        }    

        /// <summary>
        /// SeePeople - SeePeople
        /// </summary>
        public Task SeePeople(String content, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var payload = this.CreatePayload(content);
            return this.SeePeople(payload, replyHandler, timeoutHandler, waitTimeout);
        }

        /// <summary>
        /// SeePeople - SeePeople
        /// </summary>
        public Task SeePeople(StandardPayload payload, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SendMessage("armediator.general.person.seepeople", payload, replyHandler, timeoutHandler, waitTimeout);
        }
        /// <summary>
        /// StartConversation - StartConversation
        /// </summary>
        public Task StartConversation(PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.StartConversation(this.CreatePayload(), replyHandler, timeoutHandler, waitTimeout);
        }    

        /// <summary>
        /// StartConversation - StartConversation
        /// </summary>
        public Task StartConversation(String content, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var payload = this.CreatePayload(content);
            return this.StartConversation(payload, replyHandler, timeoutHandler, waitTimeout);
        }

        /// <summary>
        /// StartConversation - StartConversation
        /// </summary>
        public Task StartConversation(StandardPayload payload, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SendMessage("armediator.conversation.person.startconversation", payload, replyHandler, timeoutHandler, waitTimeout);
        }
        /// <summary>
        /// YesAnd - YesAnd
        /// </summary>
        public Task YesAnd(PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.YesAnd(this.CreatePayload(), replyHandler, timeoutHandler, waitTimeout);
        }    

        /// <summary>
        /// YesAnd - YesAnd
        /// </summary>
        public Task YesAnd(String content, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var payload = this.CreatePayload(content);
            return this.YesAnd(payload, replyHandler, timeoutHandler, waitTimeout);
        }

        /// <summary>
        /// YesAnd - YesAnd
        /// </summary>
        public Task YesAnd(StandardPayload payload, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SendMessage("armediator.chat.person.yesand", payload, replyHandler, timeoutHandler, waitTimeout);
        }
        /// <summary>
        /// YesBut - YesBut
        /// </summary>
        public Task YesBut(PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.YesBut(this.CreatePayload(), replyHandler, timeoutHandler, waitTimeout);
        }    

        /// <summary>
        /// YesBut - YesBut
        /// </summary>
        public Task YesBut(String content, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var payload = this.CreatePayload(content);
            return this.YesBut(payload, replyHandler, timeoutHandler, waitTimeout);
        }

        /// <summary>
        /// YesBut - YesBut
        /// </summary>
        public Task YesBut(StandardPayload payload, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SendMessage("armediator.chat.person.yesbut", payload, replyHandler, timeoutHandler, waitTimeout);
        }
        /// <summary>
        /// NoAnd - NoAnd
        /// </summary>
        public Task NoAnd(PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.NoAnd(this.CreatePayload(), replyHandler, timeoutHandler, waitTimeout);
        }    

        /// <summary>
        /// NoAnd - NoAnd
        /// </summary>
        public Task NoAnd(String content, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var payload = this.CreatePayload(content);
            return this.NoAnd(payload, replyHandler, timeoutHandler, waitTimeout);
        }

        /// <summary>
        /// NoAnd - NoAnd
        /// </summary>
        public Task NoAnd(StandardPayload payload, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SendMessage("armediator.chat.person.noand", payload, replyHandler, timeoutHandler, waitTimeout);
        }
        /// <summary>
        /// NoBut - NoBut
        /// </summary>
        public Task NoBut(PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.NoBut(this.CreatePayload(), replyHandler, timeoutHandler, waitTimeout);
        }    

        /// <summary>
        /// NoBut - NoBut
        /// </summary>
        public Task NoBut(String content, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var payload = this.CreatePayload(content);
            return this.NoBut(payload, replyHandler, timeoutHandler, waitTimeout);
        }

        /// <summary>
        /// NoBut - NoBut
        /// </summary>
        public Task NoBut(StandardPayload payload, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SendMessage("armediator.chat.person.nobut", payload, replyHandler, timeoutHandler, waitTimeout);
        }
        /// <summary>
        /// SuggestTopic - SuggestTopic
        /// </summary>
        public Task SuggestTopic(PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SuggestTopic(this.CreatePayload(), replyHandler, timeoutHandler, waitTimeout);
        }    

        /// <summary>
        /// SuggestTopic - SuggestTopic
        /// </summary>
        public Task SuggestTopic(String content, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var payload = this.CreatePayload(content);
            return this.SuggestTopic(payload, replyHandler, timeoutHandler, waitTimeout);
        }

        /// <summary>
        /// SuggestTopic - SuggestTopic
        /// </summary>
        public Task SuggestTopic(StandardPayload payload, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SendMessage("armediator.conversation.person.suggesttopic", payload, replyHandler, timeoutHandler, waitTimeout);
        }
        /// <summary>
        /// SuggestMoreSpecifically - SuggestMoreSpecifically
        /// </summary>
        public Task SuggestMoreSpecifically(PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SuggestMoreSpecifically(this.CreatePayload(), replyHandler, timeoutHandler, waitTimeout);
        }    

        /// <summary>
        /// SuggestMoreSpecifically - SuggestMoreSpecifically
        /// </summary>
        public Task SuggestMoreSpecifically(String content, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var payload = this.CreatePayload(content);
            return this.SuggestMoreSpecifically(payload, replyHandler, timeoutHandler, waitTimeout);
        }

        /// <summary>
        /// SuggestMoreSpecifically - SuggestMoreSpecifically
        /// </summary>
        public Task SuggestMoreSpecifically(StandardPayload payload, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SendMessage("armediator.conversation.person.suggestmorespecifically", payload, replyHandler, timeoutHandler, waitTimeout);
        }
        /// <summary>
        /// RequestAgreement - RequestAgreement
        /// </summary>
        public Task RequestAgreement(PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.RequestAgreement(this.CreatePayload(), replyHandler, timeoutHandler, waitTimeout);
        }    

        /// <summary>
        /// RequestAgreement - RequestAgreement
        /// </summary>
        public Task RequestAgreement(String content, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var payload = this.CreatePayload(content);
            return this.RequestAgreement(payload, replyHandler, timeoutHandler, waitTimeout);
        }

        /// <summary>
        /// RequestAgreement - RequestAgreement
        /// </summary>
        public Task RequestAgreement(StandardPayload payload, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SendMessage("armediator.agreement.person.requestagreement", payload, replyHandler, timeoutHandler, waitTimeout);
        }
        /// <summary>
        /// SuggestAbstraction - SuggestAbstraction
        /// </summary>
        public Task SuggestAbstraction(PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SuggestAbstraction(this.CreatePayload(), replyHandler, timeoutHandler, waitTimeout);
        }    

        /// <summary>
        /// SuggestAbstraction - SuggestAbstraction
        /// </summary>
        public Task SuggestAbstraction(String content, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var payload = this.CreatePayload(content);
            return this.SuggestAbstraction(payload, replyHandler, timeoutHandler, waitTimeout);
        }

        /// <summary>
        /// SuggestAbstraction - SuggestAbstraction
        /// </summary>
        public Task SuggestAbstraction(StandardPayload payload, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SendMessage("armediator.abstraction.person.suggestabstraction", payload, replyHandler, timeoutHandler, waitTimeout);
        }
        /// <summary>
        /// SuggestChangeInAbstraction - SuggestChangeInAbstraction
        /// </summary>
        public Task SuggestChangeInAbstraction(PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SuggestChangeInAbstraction(this.CreatePayload(), replyHandler, timeoutHandler, waitTimeout);
        }    

        /// <summary>
        /// SuggestChangeInAbstraction - SuggestChangeInAbstraction
        /// </summary>
        public Task SuggestChangeInAbstraction(String content, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var payload = this.CreatePayload(content);
            return this.SuggestChangeInAbstraction(payload, replyHandler, timeoutHandler, waitTimeout);
        }

        /// <summary>
        /// SuggestChangeInAbstraction - SuggestChangeInAbstraction
        /// </summary>
        public Task SuggestChangeInAbstraction(StandardPayload payload, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SendMessage("armediator.abstraction.person.suggestchangeinabstraction", payload, replyHandler, timeoutHandler, waitTimeout);
        }
        /// <summary>
        /// RequestFocus - RequestFocus
        /// </summary>
        public Task RequestFocus(PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.RequestFocus(this.CreatePayload(), replyHandler, timeoutHandler, waitTimeout);
        }    

        /// <summary>
        /// RequestFocus - RequestFocus
        /// </summary>
        public Task RequestFocus(String content, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var payload = this.CreatePayload(content);
            return this.RequestFocus(payload, replyHandler, timeoutHandler, waitTimeout);
        }

        /// <summary>
        /// RequestFocus - RequestFocus
        /// </summary>
        public Task RequestFocus(StandardPayload payload, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SendMessage("armediator.agreement.person.requestfocus", payload, replyHandler, timeoutHandler, waitTimeout);
        }
        /// <summary>
        /// SuggestAbstractionRemoval - SuggestAbstractionRemoval
        /// </summary>
        public Task SuggestAbstractionRemoval(PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SuggestAbstractionRemoval(this.CreatePayload(), replyHandler, timeoutHandler, waitTimeout);
        }    

        /// <summary>
        /// SuggestAbstractionRemoval - SuggestAbstractionRemoval
        /// </summary>
        public Task SuggestAbstractionRemoval(String content, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var payload = this.CreatePayload(content);
            return this.SuggestAbstractionRemoval(payload, replyHandler, timeoutHandler, waitTimeout);
        }

        /// <summary>
        /// SuggestAbstractionRemoval - SuggestAbstractionRemoval
        /// </summary>
        public Task SuggestAbstractionRemoval(StandardPayload payload, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SendMessage("armediator.general.person.suggestabstractionremoval", payload, replyHandler, timeoutHandler, waitTimeout);
        }
        /// <summary>
        /// DirectMessage - A mediated directed message (through ARMediator)
        /// </summary>
        public Task DirectMessage(PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.DirectMessage(this.CreatePayload(), replyHandler, timeoutHandler, waitTimeout);
        }    

        /// <summary>
        /// DirectMessage - A mediated directed message (through ARMediator)
        /// </summary>
        public Task DirectMessage(String content, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var payload = this.CreatePayload(content);
            return this.DirectMessage(payload, replyHandler, timeoutHandler, waitTimeout);
        }

        /// <summary>
        /// DirectMessage - A mediated directed message (through ARMediator)
        /// </summary>
        public Task DirectMessage(StandardPayload payload, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SendMessage("armediator.chat.person.directmessage", payload, replyHandler, timeoutHandler, waitTimeout);
        }
    }
}

                    
