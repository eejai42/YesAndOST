using System;
using System.Linq;
using RabbitMQ.Client;
using System.Text;
using Newtonsoft.Json;
using RabbitMQ.Client.Events;
using System.Threading.Tasks;

namespace YA.SassyMQ.Lib.RabbitMQ
{
    public partial class SMQARMediator : SMQActorBase
    {

        public SMQARMediator(String amqpConnectionString)
            : base(amqpConnectionString, "armediator")
        {
        }

        protected override void CheckRouting(StandardPayload payload, BasicDeliverEventArgs  bdea)
        {
            try
            {
                switch (bdea.RoutingKey)
                {
                    
                    case "armediator.general.person.hello":
                        this.OnPersonHelloReceived(payload, bdea);
                        break;
                    
                    case "armediator.general.person.seepeople":
                        this.OnPersonSeePeopleReceived(payload, bdea);
                        break;
                    
                    case "armediator.conversation.person.startconversation":
                        this.OnPersonStartConversationReceived(payload, bdea);
                        break;
                    
                    case "armediator.chat.person.yesand":
                        this.OnPersonYesAndReceived(payload, bdea);
                        break;
                    
                    case "armediator.chat.person.yesbut":
                        this.OnPersonYesButReceived(payload, bdea);
                        break;
                    
                    case "armediator.chat.person.noand":
                        this.OnPersonNoAndReceived(payload, bdea);
                        break;
                    
                    case "armediator.chat.person.nobut":
                        this.OnPersonNoButReceived(payload, bdea);
                        break;
                    
                    case "armediator.conversation.person.suggesttopic":
                        this.OnPersonSuggestTopicReceived(payload, bdea);
                        break;
                    
                    case "armediator.conversation.person.suggestmorespecifically":
                        this.OnPersonSuggestMoreSpecificallyReceived(payload, bdea);
                        break;
                    
                    case "armediator.agreement.person.requestagreement":
                        this.OnPersonRequestAgreementReceived(payload, bdea);
                        break;
                    
                    case "armediator.abstraction.person.suggestabstraction":
                        this.OnPersonSuggestAbstractionReceived(payload, bdea);
                        break;
                    
                    case "armediator.abstraction.person.suggestchangeinabstraction":
                        this.OnPersonSuggestChangeInAbstractionReceived(payload, bdea);
                        break;
                    
                    case "armediator.agreement.person.requestfocus":
                        this.OnPersonRequestFocusReceived(payload, bdea);
                        break;
                    
                    case "armediator.general.person.suggestabstractionremoval":
                        this.OnPersonSuggestAbstractionRemovalReceived(payload, bdea);
                        break;
                    
                    case "armediator.chat.person.directmessage":
                        this.OnPersonDirectMessageReceived(payload, bdea);
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
        /// Responds to: Hello from Person
        /// </summary>
        public event EventHandler<PayloadEventArgs> PersonHelloReceived;
        protected virtual void OnPersonHelloReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.PersonHelloReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.PersonHelloReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: SeePeople from Person
        /// </summary>
        public event EventHandler<PayloadEventArgs> PersonSeePeopleReceived;
        protected virtual void OnPersonSeePeopleReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.PersonSeePeopleReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.PersonSeePeopleReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: StartConversation from Person
        /// </summary>
        public event EventHandler<PayloadEventArgs> PersonStartConversationReceived;
        protected virtual void OnPersonStartConversationReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.PersonStartConversationReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.PersonStartConversationReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: YesAnd from Person
        /// </summary>
        public event EventHandler<PayloadEventArgs> PersonYesAndReceived;
        protected virtual void OnPersonYesAndReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.PersonYesAndReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.PersonYesAndReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: YesBut from Person
        /// </summary>
        public event EventHandler<PayloadEventArgs> PersonYesButReceived;
        protected virtual void OnPersonYesButReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.PersonYesButReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.PersonYesButReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: NoAnd from Person
        /// </summary>
        public event EventHandler<PayloadEventArgs> PersonNoAndReceived;
        protected virtual void OnPersonNoAndReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.PersonNoAndReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.PersonNoAndReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: NoBut from Person
        /// </summary>
        public event EventHandler<PayloadEventArgs> PersonNoButReceived;
        protected virtual void OnPersonNoButReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.PersonNoButReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.PersonNoButReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: SuggestTopic from Person
        /// </summary>
        public event EventHandler<PayloadEventArgs> PersonSuggestTopicReceived;
        protected virtual void OnPersonSuggestTopicReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.PersonSuggestTopicReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.PersonSuggestTopicReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: SuggestMoreSpecifically from Person
        /// </summary>
        public event EventHandler<PayloadEventArgs> PersonSuggestMoreSpecificallyReceived;
        protected virtual void OnPersonSuggestMoreSpecificallyReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.PersonSuggestMoreSpecificallyReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.PersonSuggestMoreSpecificallyReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: RequestAgreement from Person
        /// </summary>
        public event EventHandler<PayloadEventArgs> PersonRequestAgreementReceived;
        protected virtual void OnPersonRequestAgreementReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.PersonRequestAgreementReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.PersonRequestAgreementReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: SuggestAbstraction from Person
        /// </summary>
        public event EventHandler<PayloadEventArgs> PersonSuggestAbstractionReceived;
        protected virtual void OnPersonSuggestAbstractionReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.PersonSuggestAbstractionReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.PersonSuggestAbstractionReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: SuggestChangeInAbstraction from Person
        /// </summary>
        public event EventHandler<PayloadEventArgs> PersonSuggestChangeInAbstractionReceived;
        protected virtual void OnPersonSuggestChangeInAbstractionReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.PersonSuggestChangeInAbstractionReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.PersonSuggestChangeInAbstractionReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: RequestFocus from Person
        /// </summary>
        public event EventHandler<PayloadEventArgs> PersonRequestFocusReceived;
        protected virtual void OnPersonRequestFocusReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.PersonRequestFocusReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.PersonRequestFocusReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: SuggestAbstractionRemoval from Person
        /// </summary>
        public event EventHandler<PayloadEventArgs> PersonSuggestAbstractionRemovalReceived;
        protected virtual void OnPersonSuggestAbstractionRemovalReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.PersonSuggestAbstractionRemovalReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.PersonSuggestAbstractionRemovalReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: DirectMessage from Person
        /// </summary>
        public event EventHandler<PayloadEventArgs> PersonDirectMessageReceived;
        protected virtual void OnPersonDirectMessageReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.PersonDirectMessageReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.PersonDirectMessageReceived(this, plea);
            }
        }

        /// <summary>
        /// ConversationRequested - ConversationRequested
        /// </summary>
        public Task ConversationRequested(PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.ConversationRequested(this.CreatePayload(), replyHandler, timeoutHandler, waitTimeout);
        }    

        /// <summary>
        /// ConversationRequested - ConversationRequested
        /// </summary>
        public Task ConversationRequested(String content, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var payload = this.CreatePayload(content);
            return this.ConversationRequested(payload, replyHandler, timeoutHandler, waitTimeout);
        }

        /// <summary>
        /// ConversationRequested - ConversationRequested
        /// </summary>
        public Task ConversationRequested(StandardPayload payload, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SendMessage("person.conversation.armediator.conversationrequested", payload, replyHandler, timeoutHandler, waitTimeout);
        }
        /// <summary>
        /// AgreementRequested - AgreementRequested
        /// </summary>
        public Task AgreementRequested(PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.AgreementRequested(this.CreatePayload(), replyHandler, timeoutHandler, waitTimeout);
        }    

        /// <summary>
        /// AgreementRequested - AgreementRequested
        /// </summary>
        public Task AgreementRequested(String content, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var payload = this.CreatePayload(content);
            return this.AgreementRequested(payload, replyHandler, timeoutHandler, waitTimeout);
        }

        /// <summary>
        /// AgreementRequested - AgreementRequested
        /// </summary>
        public Task AgreementRequested(StandardPayload payload, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SendMessage("person.agreement.armediator.agreementrequested", payload, replyHandler, timeoutHandler, waitTimeout);
        }
        /// <summary>
        /// DMForYou - A mediated directed message (through ARMediator)
        /// </summary>
        public Task DMForYou(PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.DMForYou(this.CreatePayload(), replyHandler, timeoutHandler, waitTimeout);
        }    

        /// <summary>
        /// DMForYou - A mediated directed message (through ARMediator)
        /// </summary>
        public Task DMForYou(String content, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var payload = this.CreatePayload(content);
            return this.DMForYou(payload, replyHandler, timeoutHandler, waitTimeout);
        }

        /// <summary>
        /// DMForYou - A mediated directed message (through ARMediator)
        /// </summary>
        public Task DMForYou(StandardPayload payload, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SendMessage("person.chat.armediator.dmforyou", payload, replyHandler, timeoutHandler, waitTimeout);
        }
    }
}

                    
