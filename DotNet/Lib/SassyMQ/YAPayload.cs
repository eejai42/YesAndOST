using SassyMQ.Lib.RabbitMQ.Payload;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YesAndOST.Lib.DataClasses;

namespace SassyMQ.YA.Lib.RMQActors
{
    public class YAPayload : StandardPayload<YAPayload>
    {
        public Person Person { get; set; }
        public List<Avatar> People { get; set; }
        public Avatar Avatar { get; set; }
        public bool IsDirectMessage { get; internal set; }
        public Statement Statement { get; set; }
    }
}
