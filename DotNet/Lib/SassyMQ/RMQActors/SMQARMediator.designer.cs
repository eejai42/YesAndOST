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
    public partial class SMQARMediator : YAActorBase
    {
     
        public SMQARMediator(bool isAutoConnect = true)
            : base("armediator.all", isAutoConnect)
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
                
             if (payload.IsLexiconTerm(LexiconTermEnum.person_hello_armediator)) 
            {
                this.OnPersonHelloReceived(payload);
            }
        
            else  if (payload.IsLexiconTerm(LexiconTermEnum.person_seepeople_armediator)) 
            {
                this.OnPersonSeePeopleReceived(payload);
            }
        
            else  if (payload.IsLexiconTerm(LexiconTermEnum.person_startconversation_armediator)) 
            {
                this.OnPersonStartConversationReceived(payload);
            }
        
            else  if (payload.IsLexiconTerm(LexiconTermEnum.person_yesand_armediator)) 
            {
                this.OnPersonYesAndReceived(payload);
            }
        
            else  if (payload.IsLexiconTerm(LexiconTermEnum.person_yesbut_armediator)) 
            {
                this.OnPersonYesButReceived(payload);
            }
        
            else  if (payload.IsLexiconTerm(LexiconTermEnum.person_noand_armediator)) 
            {
                this.OnPersonNoAndReceived(payload);
            }
        
            else  if (payload.IsLexiconTerm(LexiconTermEnum.person_nobut_armediator)) 
            {
                this.OnPersonNoButReceived(payload);
            }
        
            else  if (payload.IsLexiconTerm(LexiconTermEnum.person_suggesttopic_armediator)) 
            {
                this.OnPersonSuggestTopicReceived(payload);
            }
        
            else  if (payload.IsLexiconTerm(LexiconTermEnum.person_suggestmorespecifically_armediator)) 
            {
                this.OnPersonSuggestMoreSpecificallyReceived(payload);
            }
        
            else  if (payload.IsLexiconTerm(LexiconTermEnum.person_requestagreement_armediator)) 
            {
                this.OnPersonRequestAgreementReceived(payload);
            }
        
            else  if (payload.IsLexiconTerm(LexiconTermEnum.person_suggestabstraction_armediator)) 
            {
                this.OnPersonSuggestAbstractionReceived(payload);
            }
        
            else  if (payload.IsLexiconTerm(LexiconTermEnum.person_suggestchangeinabstraction_armediator)) 
            {
                this.OnPersonSuggestChangeInAbstractionReceived(payload);
            }
        
            else  if (payload.IsLexiconTerm(LexiconTermEnum.person_requestfocus_armediator)) 
            {
                this.OnPersonRequestFocusReceived(payload);
            }
        
            else  if (payload.IsLexiconTerm(LexiconTermEnum.person_suggestabstractionremoval_armediator)) 
            {
                this.OnPersonSuggestAbstractionRemovalReceived(payload);
            }
        
            } catch (Exception ex) {
                payload.Exception = ex;
            }
            this.Reply(payload);
        }

        
        /// <summary>
        /// Responds to: Hello - Hello
        /// </summary>
        public event System.EventHandler<PayloadEventArgs<YAPayload>> PersonHelloReceived;
        protected virtual void OnPersonHelloReceived(YAPayload payload)
        {
            this.LogMessage(payload, "Hello - Hello");
            var plea = new PayloadEventArgs<YAPayload>(payload);
            this.Invoke(this.PersonHelloReceived, plea);
        }
        
        /// <summary>
        /// Responds to: See People - SeePeople
        /// </summary>
        public event System.EventHandler<PayloadEventArgs<YAPayload>> PersonSeePeopleReceived;
        protected virtual void OnPersonSeePeopleReceived(YAPayload payload)
        {
            this.LogMessage(payload, "See People - SeePeople");
            var plea = new PayloadEventArgs<YAPayload>(payload);
            this.Invoke(this.PersonSeePeopleReceived, plea);
        }
        
        /// <summary>
        /// Responds to: Start Conversation - StartConversation
        /// </summary>
        public event System.EventHandler<PayloadEventArgs<YAPayload>> PersonStartConversationReceived;
        protected virtual void OnPersonStartConversationReceived(YAPayload payload)
        {
            this.LogMessage(payload, "Start Conversation - StartConversation");
            var plea = new PayloadEventArgs<YAPayload>(payload);
            this.Invoke(this.PersonStartConversationReceived, plea);
        }
        
        /// <summary>
        /// Responds to: Yes And - YesAnd
        /// </summary>
        public event System.EventHandler<PayloadEventArgs<YAPayload>> PersonYesAndReceived;
        protected virtual void OnPersonYesAndReceived(YAPayload payload)
        {
            this.LogMessage(payload, "Yes And - YesAnd");
            var plea = new PayloadEventArgs<YAPayload>(payload);
            this.Invoke(this.PersonYesAndReceived, plea);
        }
        
        /// <summary>
        /// Responds to: Yes But - YesBut
        /// </summary>
        public event System.EventHandler<PayloadEventArgs<YAPayload>> PersonYesButReceived;
        protected virtual void OnPersonYesButReceived(YAPayload payload)
        {
            this.LogMessage(payload, "Yes But - YesBut");
            var plea = new PayloadEventArgs<YAPayload>(payload);
            this.Invoke(this.PersonYesButReceived, plea);
        }
        
        /// <summary>
        /// Responds to: No And - NoAnd
        /// </summary>
        public event System.EventHandler<PayloadEventArgs<YAPayload>> PersonNoAndReceived;
        protected virtual void OnPersonNoAndReceived(YAPayload payload)
        {
            this.LogMessage(payload, "No And - NoAnd");
            var plea = new PayloadEventArgs<YAPayload>(payload);
            this.Invoke(this.PersonNoAndReceived, plea);
        }
        
        /// <summary>
        /// Responds to: No But - NoBut
        /// </summary>
        public event System.EventHandler<PayloadEventArgs<YAPayload>> PersonNoButReceived;
        protected virtual void OnPersonNoButReceived(YAPayload payload)
        {
            this.LogMessage(payload, "No But - NoBut");
            var plea = new PayloadEventArgs<YAPayload>(payload);
            this.Invoke(this.PersonNoButReceived, plea);
        }
        
        /// <summary>
        /// Responds to: Suggest Topic - SuggestTopic
        /// </summary>
        public event System.EventHandler<PayloadEventArgs<YAPayload>> PersonSuggestTopicReceived;
        protected virtual void OnPersonSuggestTopicReceived(YAPayload payload)
        {
            this.LogMessage(payload, "Suggest Topic - SuggestTopic");
            var plea = new PayloadEventArgs<YAPayload>(payload);
            this.Invoke(this.PersonSuggestTopicReceived, plea);
        }
        
        /// <summary>
        /// Responds to: Suggest More Specifically - SuggestMoreSpecifically
        /// </summary>
        public event System.EventHandler<PayloadEventArgs<YAPayload>> PersonSuggestMoreSpecificallyReceived;
        protected virtual void OnPersonSuggestMoreSpecificallyReceived(YAPayload payload)
        {
            this.LogMessage(payload, "Suggest More Specifically - SuggestMoreSpecifically");
            var plea = new PayloadEventArgs<YAPayload>(payload);
            this.Invoke(this.PersonSuggestMoreSpecificallyReceived, plea);
        }
        
        /// <summary>
        /// Responds to: Request Agreement - RequestAgreement
        /// </summary>
        public event System.EventHandler<PayloadEventArgs<YAPayload>> PersonRequestAgreementReceived;
        protected virtual void OnPersonRequestAgreementReceived(YAPayload payload)
        {
            this.LogMessage(payload, "Request Agreement - RequestAgreement");
            var plea = new PayloadEventArgs<YAPayload>(payload);
            this.Invoke(this.PersonRequestAgreementReceived, plea);
        }
        
        /// <summary>
        /// Responds to: Suggest Abstraction - SuggestAbstraction
        /// </summary>
        public event System.EventHandler<PayloadEventArgs<YAPayload>> PersonSuggestAbstractionReceived;
        protected virtual void OnPersonSuggestAbstractionReceived(YAPayload payload)
        {
            this.LogMessage(payload, "Suggest Abstraction - SuggestAbstraction");
            var plea = new PayloadEventArgs<YAPayload>(payload);
            this.Invoke(this.PersonSuggestAbstractionReceived, plea);
        }
        
        /// <summary>
        /// Responds to: Suggest Change In Abstraction - SuggestChangeInAbstraction
        /// </summary>
        public event System.EventHandler<PayloadEventArgs<YAPayload>> PersonSuggestChangeInAbstractionReceived;
        protected virtual void OnPersonSuggestChangeInAbstractionReceived(YAPayload payload)
        {
            this.LogMessage(payload, "Suggest Change In Abstraction - SuggestChangeInAbstraction");
            var plea = new PayloadEventArgs<YAPayload>(payload);
            this.Invoke(this.PersonSuggestChangeInAbstractionReceived, plea);
        }
        
        /// <summary>
        /// Responds to: Request Focus - RequestFocus
        /// </summary>
        public event System.EventHandler<PayloadEventArgs<YAPayload>> PersonRequestFocusReceived;
        protected virtual void OnPersonRequestFocusReceived(YAPayload payload)
        {
            this.LogMessage(payload, "Request Focus - RequestFocus");
            var plea = new PayloadEventArgs<YAPayload>(payload);
            this.Invoke(this.PersonRequestFocusReceived, plea);
        }
        
        /// <summary>
        /// Responds to: Suggest Abstraction Removal - SuggestAbstractionRemoval
        /// </summary>
        public event System.EventHandler<PayloadEventArgs<YAPayload>> PersonSuggestAbstractionRemovalReceived;
        protected virtual void OnPersonSuggestAbstractionRemovalReceived(YAPayload payload)
        {
            this.LogMessage(payload, "Suggest Abstraction Removal - SuggestAbstractionRemoval");
            var plea = new PayloadEventArgs<YAPayload>(payload);
            this.Invoke(this.PersonSuggestAbstractionRemovalReceived, plea);
        }
        
        /// <summary>
        /// Conversation Requested - ConversationRequested
        /// </summary>
        public void ARMediatorConversationRequested() 
        {
            this.ARMediatorConversationRequested(this.CreatePayload());
        }

        /// <summary>
        /// Conversation Requested - ConversationRequested
        /// </summary>
        public void ARMediatorConversationRequested(System.String content) 
        {
            var payload = this.CreatePayload();
            payload.Content = content;
            this.ARMediatorConversationRequested(payload);
        }

        /// <summary>
        /// Conversation Requested - ConversationRequested
        /// </summary>
        public void ARMediatorConversationRequested(YAPayload payload)
        {
            
            this.SendMessage(payload, "Conversation Requested - ConversationRequested",
            "armediatormic", "person.conversation.armediator.conversationrequested");
        }


        
        /// <summary>
        /// Agreement Requested - AgreementRequested
        /// </summary>
        public void ARMediatorAgreementRequested() 
        {
            this.ARMediatorAgreementRequested(this.CreatePayload());
        }

        /// <summary>
        /// Agreement Requested - AgreementRequested
        /// </summary>
        public void ARMediatorAgreementRequested(System.String content) 
        {
            var payload = this.CreatePayload();
            payload.Content = content;
            this.ARMediatorAgreementRequested(payload);
        }

        /// <summary>
        /// Agreement Requested - AgreementRequested
        /// </summary>
        public void ARMediatorAgreementRequested(YAPayload payload)
        {
            
            this.SendMessage(payload, "Agreement Requested - AgreementRequested",
            "armediatormic", "person.agreement.armediator.agreementrequested");
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

                    