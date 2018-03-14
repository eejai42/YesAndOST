

using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQ.Client.MessagePatterns;
using SassyMQ.Lib.RabbitMQ;
using SassyMQ.YA.Lib.RabbitMQ;
using SassyMQ.Lib.RabbitMQ.Payload;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SassyMQ.YA.Lib.RMQActors;

namespace SassyMQ.YA.Lib
{
    public abstract class YAActorBase : SMQActorBase<YAPayload> 
    {
        public YAActorBase(string allExchange, bool isAutoConnect) : base(allExchange, isAutoConnect)
        {
        }
    }
}