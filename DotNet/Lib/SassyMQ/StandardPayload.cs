using Newtonsoft.Json;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using YesAndOST.Lib.DataClasses;

namespace YA.SassyMQ.Lib.RabbitMQ
{
    public partial class StandardPayload
    {
        public const int DEFAULT_TIMEOUT = 30;

        public Person Person { get; set; }
        public List<Avatar> People { get; set; }
        public Avatar Avatar { get; set; }
        public bool IsDirectMessage { get; internal set; }
        public Statement Statement { get; set; }

        public StandardPayload()
            : this(default(SMQActorBase))
        {

        }

        public StandardPayload(SMQActorBase actor)
            : this(actor, String.Empty)
        {

        }
        
        public StandardPayload(SMQActorBase actor, string content)
            : this(actor, content, true)
        {
        }

        internal void SetActor(SMQActorBase sMQActorBase)
        {
            // DO NOTHING AT THIS POINT
        }
    }
}