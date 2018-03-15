using System;
using System.Linq;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQ.Client.MessagePatterns;
using SassyMQ.Lib.RabbitMQ;
using SassyMQ.YA.Lib.RabbitMQ;
using SassyMQ.Lib.RabbitMQ.Payload;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SassyMQ.YA.Lib;
using CoreLibrary.SassyMQ;

namespace SassyMQ.YA.Lib.RMQActors
{
    public partial class SMQPerson : YAActorBase
    {
     
        public SMQPerson(bool isAutoConnect = true)
            : base("person.all", isAutoConnect)
        {
        }
        // YesAnd - YA
        public virtual bool Connect(string virtualHost, string username, string password)
        {
            return base.Connect(virtualHost, username, password);
        }   

        protected override void CheckRouting(YAPayload payload) 
        {
            this.CheckRouting(payload, false);
        }

        partial void CheckPayload(YAPayload payload);

        private void Reply(YAPayload payload)
        {
            if (!System.String.IsNullOrEmpty(payload.ReplyTo))
            {
                payload.DirectMessageQueue = this.QueueName;
                this.CheckPayload(payload);
                this.RMQChannel.BasicPublish("", payload.ReplyTo, body: Encoding.UTF8.GetBytes(payload.ToJSonString()));
            }
        }

        protected override void CheckRouting(YAPayload payload, bool isDirectMessage) 
        {
            // if (payload.IsDirectMessage && !isDirectMessage) return;

            try {
                
             if (payload.IsLexiconTerm(LexiconTermEnum.armediator_conversationrequested_person)) 
            {
                this.OnARMediatorConversationRequestedReceived(payload);
            }
        
            else  if (payload.IsLexiconTerm(LexiconTermEnum.armediator_agreementrequested_person)) 
            {
                this.OnARMediatorAgreementRequestedReceived(payload);
            }
        
            else  if (payload.IsLexiconTerm(LexiconTermEnum.armediator_dmforyou_person)) 
            {
                this.OnARMediatorDMForYouReceived(payload);
            }
        
            } catch (Exception ex) {
                payload.Exception = ex;
            }
            this.Reply(payload);
        }

        
        /// <summary>
        /// Responds to: Conversation Requested - ConversationRequested
        /// </summary>
        public event System.EventHandler<PayloadEventArgs<YAPayload>> ARMediatorConversationRequestedReceived;
        protected virtual void OnARMediatorConversationRequestedReceived(YAPayload payload)
        {
            this.LogMessage(payload, "Conversation Requested - ConversationRequested");
            var plea = new PayloadEventArgs<YAPayload>(payload);
            this.Invoke(this.ARMediatorConversationRequestedReceived, plea);
        }
        
        /// <summary>
        /// Responds to: Agreement Requested - AgreementRequested
        /// </summary>
        public event System.EventHandler<PayloadEventArgs<YAPayload>> ARMediatorAgreementRequestedReceived;
        protected virtual void OnARMediatorAgreementRequestedReceived(YAPayload payload)
        {
            this.LogMessage(payload, "Agreement Requested - AgreementRequested");
            var plea = new PayloadEventArgs<YAPayload>(payload);
            this.Invoke(this.ARMediatorAgreementRequestedReceived, plea);
        }
        
        /// <summary>
        /// Responds to: D M For You - A mediated directed message (through ARMediator)
        /// </summary>
        public event System.EventHandler<PayloadEventArgs<YAPayload>> ARMediatorDMForYouReceived;
        protected virtual void OnARMediatorDMForYouReceived(YAPayload payload)
        {
            this.LogMessage(payload, "D M For You - A mediated directed message (through ARMediator)");
            var plea = new PayloadEventArgs<YAPayload>(payload);
            this.Invoke(this.ARMediatorDMForYouReceived, plea);
        }
        
        /// <summary>
        /// Hello - Hello
        /// </summary>
        public void PersonHello() 
        {
            this.PersonHello(this.CreatePayload());
        }

        /// <summary>
        /// Hello - Hello
        /// </summary>
        public void PersonHello(System.String content) 
        {
            var payload = this.CreatePayload();
            payload.Content = content;
            this.PersonHello(payload);
        }

        /// <summary>
        /// Hello - Hello
        /// </summary>
        public void PersonHello(YAPayload payload)
        {
            
            this.SendMessage(payload, "Hello - Hello",
            "personmic", "armediator.general.person.hello");
        }


        
        /// <summary>
        /// See People - SeePeople
        /// </summary>
        public void PersonSeePeople() 
        {
            this.PersonSeePeople(this.CreatePayload());
        }

        /// <summary>
        /// See People - SeePeople
        /// </summary>
        public void PersonSeePeople(System.String content) 
        {
            var payload = this.CreatePayload();
            payload.Content = content;
            this.PersonSeePeople(payload);
        }

        /// <summary>
        /// See People - SeePeople
        /// </summary>
        public void PersonSeePeople(YAPayload payload)
        {
            
            this.SendMessage(payload, "See People - SeePeople",
            "personmic", "armediator.general.person.seepeople");
        }


        
        /// <summary>
        /// Start Conversation - StartConversation
        /// </summary>
        public void PersonStartConversation() 
        {
            this.PersonStartConversation(this.CreatePayload());
        }

        /// <summary>
        /// Start Conversation - StartConversation
        /// </summary>
        public void PersonStartConversation(System.String content) 
        {
            var payload = this.CreatePayload();
            payload.Content = content;
            this.PersonStartConversation(payload);
        }

        /// <summary>
        /// Start Conversation - StartConversation
        /// </summary>
        public void PersonStartConversation(YAPayload payload)
        {
            
            this.SendMessage(payload, "Start Conversation - StartConversation",
            "personmic", "armediator.conversation.person.startconversation");
        }


        
        /// <summary>
        /// Yes And - YesAnd
        /// </summary>
        public void PersonYesAnd() 
        {
            this.PersonYesAnd(this.CreatePayload());
        }

        /// <summary>
        /// Yes And - YesAnd
        /// </summary>
        public void PersonYesAnd(System.String content) 
        {
            var payload = this.CreatePayload();
            payload.Content = content;
            this.PersonYesAnd(payload);
        }

        /// <summary>
        /// Yes And - YesAnd
        /// </summary>
        public void PersonYesAnd(YAPayload payload)
        {
            
            this.SendMessage(payload, "Yes And - YesAnd",
            "personmic", "armediator.chat.person.yesand");
        }


        
        /// <summary>
        /// Yes But - YesBut
        /// </summary>
        public void PersonYesBut() 
        {
            this.PersonYesBut(this.CreatePayload());
        }

        /// <summary>
        /// Yes But - YesBut
        /// </summary>
        public void PersonYesBut(System.String content) 
        {
            var payload = this.CreatePayload();
            payload.Content = content;
            this.PersonYesBut(payload);
        }

        /// <summary>
        /// Yes But - YesBut
        /// </summary>
        public void PersonYesBut(YAPayload payload)
        {
            
            this.SendMessage(payload, "Yes But - YesBut",
            "personmic", "armediator.chat.person.yesbut");
        }


        
        /// <summary>
        /// No And - NoAnd
        /// </summary>
        public void PersonNoAnd() 
        {
            this.PersonNoAnd(this.CreatePayload());
        }

        /// <summary>
        /// No And - NoAnd
        /// </summary>
        public void PersonNoAnd(System.String content) 
        {
            var payload = this.CreatePayload();
            payload.Content = content;
            this.PersonNoAnd(payload);
        }

        /// <summary>
        /// No And - NoAnd
        /// </summary>
        public void PersonNoAnd(YAPayload payload)
        {
            
            this.SendMessage(payload, "No And - NoAnd",
            "personmic", "armediator.chat.person.noand");
        }


        
        /// <summary>
        /// No But - NoBut
        /// </summary>
        public void PersonNoBut() 
        {
            this.PersonNoBut(this.CreatePayload());
        }

        /// <summary>
        /// No But - NoBut
        /// </summary>
        public void PersonNoBut(System.String content) 
        {
            var payload = this.CreatePayload();
            payload.Content = content;
            this.PersonNoBut(payload);
        }

        /// <summary>
        /// No But - NoBut
        /// </summary>
        public void PersonNoBut(YAPayload payload)
        {
            
            this.SendMessage(payload, "No But - NoBut",
            "personmic", "armediator.chat.person.nobut");
        }


        
        /// <summary>
        /// Suggest Topic - SuggestTopic
        /// </summary>
        public void PersonSuggestTopic() 
        {
            this.PersonSuggestTopic(this.CreatePayload());
        }

        /// <summary>
        /// Suggest Topic - SuggestTopic
        /// </summary>
        public void PersonSuggestTopic(System.String content) 
        {
            var payload = this.CreatePayload();
            payload.Content = content;
            this.PersonSuggestTopic(payload);
        }

        /// <summary>
        /// Suggest Topic - SuggestTopic
        /// </summary>
        public void PersonSuggestTopic(YAPayload payload)
        {
            
            this.SendMessage(payload, "Suggest Topic - SuggestTopic",
            "personmic", "armediator.conversation.person.suggesttopic");
        }


        
        /// <summary>
        /// Suggest More Specifically - SuggestMoreSpecifically
        /// </summary>
        public void PersonSuggestMoreSpecifically() 
        {
            this.PersonSuggestMoreSpecifically(this.CreatePayload());
        }

        /// <summary>
        /// Suggest More Specifically - SuggestMoreSpecifically
        /// </summary>
        public void PersonSuggestMoreSpecifically(System.String content) 
        {
            var payload = this.CreatePayload();
            payload.Content = content;
            this.PersonSuggestMoreSpecifically(payload);
        }

        /// <summary>
        /// Suggest More Specifically - SuggestMoreSpecifically
        /// </summary>
        public void PersonSuggestMoreSpecifically(YAPayload payload)
        {
            
            this.SendMessage(payload, "Suggest More Specifically - SuggestMoreSpecifically",
            "personmic", "armediator.conversation.person.suggestmorespecifically");
        }


        
        /// <summary>
        /// Request Agreement - RequestAgreement
        /// </summary>
        public void PersonRequestAgreement() 
        {
            this.PersonRequestAgreement(this.CreatePayload());
        }

        /// <summary>
        /// Request Agreement - RequestAgreement
        /// </summary>
        public void PersonRequestAgreement(System.String content) 
        {
            var payload = this.CreatePayload();
            payload.Content = content;
            this.PersonRequestAgreement(payload);
        }

        /// <summary>
        /// Request Agreement - RequestAgreement
        /// </summary>
        public void PersonRequestAgreement(YAPayload payload)
        {
            
            this.SendMessage(payload, "Request Agreement - RequestAgreement",
            "personmic", "armediator.agreement.person.requestagreement");
        }


        
        /// <summary>
        /// Suggest Abstraction - SuggestAbstraction
        /// </summary>
        public void PersonSuggestAbstraction() 
        {
            this.PersonSuggestAbstraction(this.CreatePayload());
        }

        /// <summary>
        /// Suggest Abstraction - SuggestAbstraction
        /// </summary>
        public void PersonSuggestAbstraction(System.String content) 
        {
            var payload = this.CreatePayload();
            payload.Content = content;
            this.PersonSuggestAbstraction(payload);
        }

        /// <summary>
        /// Suggest Abstraction - SuggestAbstraction
        /// </summary>
        public void PersonSuggestAbstraction(YAPayload payload)
        {
            
            this.SendMessage(payload, "Suggest Abstraction - SuggestAbstraction",
            "personmic", "armediator.abstraction.person.suggestabstraction");
        }


        
        /// <summary>
        /// Suggest Change In Abstraction - SuggestChangeInAbstraction
        /// </summary>
        public void PersonSuggestChangeInAbstraction() 
        {
            this.PersonSuggestChangeInAbstraction(this.CreatePayload());
        }

        /// <summary>
        /// Suggest Change In Abstraction - SuggestChangeInAbstraction
        /// </summary>
        public void PersonSuggestChangeInAbstraction(System.String content) 
        {
            var payload = this.CreatePayload();
            payload.Content = content;
            this.PersonSuggestChangeInAbstraction(payload);
        }

        /// <summary>
        /// Suggest Change In Abstraction - SuggestChangeInAbstraction
        /// </summary>
        public void PersonSuggestChangeInAbstraction(YAPayload payload)
        {
            
            this.SendMessage(payload, "Suggest Change In Abstraction - SuggestChangeInAbstraction",
            "personmic", "armediator.abstraction.person.suggestchangeinabstraction");
        }


        
        /// <summary>
        /// Request Focus - RequestFocus
        /// </summary>
        public void PersonRequestFocus() 
        {
            this.PersonRequestFocus(this.CreatePayload());
        }

        /// <summary>
        /// Request Focus - RequestFocus
        /// </summary>
        public void PersonRequestFocus(System.String content) 
        {
            var payload = this.CreatePayload();
            payload.Content = content;
            this.PersonRequestFocus(payload);
        }

        /// <summary>
        /// Request Focus - RequestFocus
        /// </summary>
        public void PersonRequestFocus(YAPayload payload)
        {
            
            this.SendMessage(payload, "Request Focus - RequestFocus",
            "personmic", "armediator.agreement.person.requestfocus");
        }


        
        /// <summary>
        /// Suggest Abstraction Removal - SuggestAbstractionRemoval
        /// </summary>
        public void PersonSuggestAbstractionRemoval() 
        {
            this.PersonSuggestAbstractionRemoval(this.CreatePayload());
        }

        /// <summary>
        /// Suggest Abstraction Removal - SuggestAbstractionRemoval
        /// </summary>
        public void PersonSuggestAbstractionRemoval(System.String content) 
        {
            var payload = this.CreatePayload();
            payload.Content = content;
            this.PersonSuggestAbstractionRemoval(payload);
        }

        /// <summary>
        /// Suggest Abstraction Removal - SuggestAbstractionRemoval
        /// </summary>
        public void PersonSuggestAbstractionRemoval(YAPayload payload)
        {
            
            this.SendMessage(payload, "Suggest Abstraction Removal - SuggestAbstractionRemoval",
            "personmic", "armediator.general.person.suggestabstractionremoval");
        }


        
        /// <summary>
        /// Direct Message - A mediated directed message (through ARMediator)
        /// </summary>
        public void PersonDirectMessage() 
        {
            this.PersonDirectMessage(this.CreatePayload());
        }

        /// <summary>
        /// Direct Message - A mediated directed message (through ARMediator)
        /// </summary>
        public void PersonDirectMessage(System.String content) 
        {
            var payload = this.CreatePayload();
            payload.Content = content;
            this.PersonDirectMessage(payload);
        }

        /// <summary>
        /// Direct Message - A mediated directed message (through ARMediator)
        /// </summary>
        public void PersonDirectMessage(YAPayload payload)
        {
            
            this.SendMessage(payload, "Direct Message - A mediated directed message (through ARMediator)",
            "personmic", "armediator.chat.person.directmessage");
        }


        

        
        public void LogMessage(YAPayload payload, System.String msg)
        {
            if (IsDebugMode)
            {
                System.Diagnostics.Debug.WriteLine(msg);
                System.Diagnostics.Debug.WriteLine("payload: " + payload.SafeToString());
            }
        }
        
    }
}

                    