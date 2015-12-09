using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lime.Protocol;

namespace Iris.Sdk
{
    public abstract class MessageReceiverBase : IMessageReceiver
    {
        public IMessageSender Sender { get; internal set; }

        public abstract Task ReceiveAsync(Message message);
    }
}
