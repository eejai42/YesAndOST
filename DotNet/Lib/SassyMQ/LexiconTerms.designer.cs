using System;

using System.Linq;
using System.Collections.Generic;
using System.Collections;
using SassyMQ.Lib.RabbitMQ;

namespace SassyMQ.YA.Lib.RabbitMQ
{
    public class LexiconTerm : LexiconTerm<LexiconTermEnum> { }

    public partial class Lexicon  : IEnumerable<LexiconTerm>
    {
        public static Lexicon Terms = new Lexicon();
        protected static new Dictionary<LexiconTermEnum, LexiconTerm> TermsByKey { get; set; }

        public LexiconTerm this[LexiconTermEnum termKey]
        {
            get { return TermsByKey[termKey]; }
        }

        public LexiconTerm FromRoutingKey(string routingKey)
        {
            return Lexicon.TermsByKey.Values.FirstOrDefault(first => first.RoutingKey == routingKey);
        }


        public IEnumerator<LexiconTerm> GetEnumerator()
        {
            return Lexicon.TermsByKey.Values.GetEnumerator();
        }

        
        IEnumerator IEnumerable.GetEnumerator()
        {
            return Lexicon.TermsByKey.Values.GetEnumerator();
        }

        static Lexicon()
        {
            Lexicon.TermsByKey = new Dictionary<LexiconTermEnum, LexiconTerm>();
            
            Lexicon.TermsByKey[LexiconTermEnum.person_hello_armediator] = new LexiconTerm() {
                Term = LexiconTermEnum.person_hello_armediator,
                Sender = "person",
                Verb = "hello",
                Receiver = "armediator",
                Category = "general"
            };
            
            Lexicon.TermsByKey[LexiconTermEnum.person_seepeople_armediator] = new LexiconTerm() {
                Term = LexiconTermEnum.person_seepeople_armediator,
                Sender = "person",
                Verb = "seepeople",
                Receiver = "armediator",
                Category = "general"
            };
            
            Lexicon.TermsByKey[LexiconTermEnum.person_startconversation_armediator] = new LexiconTerm() {
                Term = LexiconTermEnum.person_startconversation_armediator,
                Sender = "person",
                Verb = "startconversation",
                Receiver = "armediator",
                Category = "conversation"
            };
            
            Lexicon.TermsByKey[LexiconTermEnum.armediator_conversationrequested_person] = new LexiconTerm() {
                Term = LexiconTermEnum.armediator_conversationrequested_person,
                Sender = "armediator",
                Verb = "conversationrequested",
                Receiver = "person",
                Category = "conversation"
            };
            
            Lexicon.TermsByKey[LexiconTermEnum.person_yesand_armediator] = new LexiconTerm() {
                Term = LexiconTermEnum.person_yesand_armediator,
                Sender = "person",
                Verb = "yesand",
                Receiver = "armediator",
                Category = "chat"
            };
            
            Lexicon.TermsByKey[LexiconTermEnum.person_yesbut_armediator] = new LexiconTerm() {
                Term = LexiconTermEnum.person_yesbut_armediator,
                Sender = "person",
                Verb = "yesbut",
                Receiver = "armediator",
                Category = "chat"
            };
            
            Lexicon.TermsByKey[LexiconTermEnum.person_noand_armediator] = new LexiconTerm() {
                Term = LexiconTermEnum.person_noand_armediator,
                Sender = "person",
                Verb = "noand",
                Receiver = "armediator",
                Category = "chat"
            };
            
            Lexicon.TermsByKey[LexiconTermEnum.person_nobut_armediator] = new LexiconTerm() {
                Term = LexiconTermEnum.person_nobut_armediator,
                Sender = "person",
                Verb = "nobut",
                Receiver = "armediator",
                Category = "chat"
            };
            
            Lexicon.TermsByKey[LexiconTermEnum.person_suggesttopic_armediator] = new LexiconTerm() {
                Term = LexiconTermEnum.person_suggesttopic_armediator,
                Sender = "person",
                Verb = "suggesttopic",
                Receiver = "armediator",
                Category = "conversation"
            };
            
            Lexicon.TermsByKey[LexiconTermEnum.person_suggestmorespecifically_armediator] = new LexiconTerm() {
                Term = LexiconTermEnum.person_suggestmorespecifically_armediator,
                Sender = "person",
                Verb = "suggestmorespecifically",
                Receiver = "armediator",
                Category = "conversation"
            };
            
            Lexicon.TermsByKey[LexiconTermEnum.person_requestagreement_armediator] = new LexiconTerm() {
                Term = LexiconTermEnum.person_requestagreement_armediator,
                Sender = "person",
                Verb = "requestagreement",
                Receiver = "armediator",
                Category = "agreement"
            };
            
            Lexicon.TermsByKey[LexiconTermEnum.armediator_agreementrequested_person] = new LexiconTerm() {
                Term = LexiconTermEnum.armediator_agreementrequested_person,
                Sender = "armediator",
                Verb = "agreementrequested",
                Receiver = "person",
                Category = "agreement"
            };
            
            Lexicon.TermsByKey[LexiconTermEnum.person_suggestabstraction_armediator] = new LexiconTerm() {
                Term = LexiconTermEnum.person_suggestabstraction_armediator,
                Sender = "person",
                Verb = "suggestabstraction",
                Receiver = "armediator",
                Category = "abstraction"
            };
            
            Lexicon.TermsByKey[LexiconTermEnum.person_suggestchangeinabstraction_armediator] = new LexiconTerm() {
                Term = LexiconTermEnum.person_suggestchangeinabstraction_armediator,
                Sender = "person",
                Verb = "suggestchangeinabstraction",
                Receiver = "armediator",
                Category = "abstraction"
            };
            
            Lexicon.TermsByKey[LexiconTermEnum.person_requestfocus_armediator] = new LexiconTerm() {
                Term = LexiconTermEnum.person_requestfocus_armediator,
                Sender = "person",
                Verb = "requestfocus",
                Receiver = "armediator",
                Category = "agreement"
            };
            
            Lexicon.TermsByKey[LexiconTermEnum.person_suggestabstractionremoval_armediator] = new LexiconTerm() {
                Term = LexiconTermEnum.person_suggestabstractionremoval_armediator,
                Sender = "person",
                Verb = "suggestabstractionremoval",
                Receiver = "armediator",
                Category = "general"
            };
            
        }
    }
}