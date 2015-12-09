using System;
using System.Threading.Tasks;
using Lime.Protocol;
using Lime.Protocol.Client;
using Lime.Messaging.Contents;

namespace Iris.Sdk
{
    // TODO Add locking or queue to prevent simultaneous access to channel 
    internal class MessageSenderWrapper : IMessageSender
    {
        IClientChannel clientChannel;

        public MessageSenderWrapper(IClientChannel clientChannel)
        {
            this.clientChannel = clientChannel;
        }

        public Task SendMessageAsync(string content)
        {
            var message = new Message
            {
                Content = new PlainText { Text = content }
            };
            return clientChannel.SendMessageAsync(message);
        }

        public Task SendMessageAsync(Message message)
        {
            return clientChannel.SendMessageAsync(message);
        }
    }
}