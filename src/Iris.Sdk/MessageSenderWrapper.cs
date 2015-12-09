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

        public Task SendMessageAsync(string content, string to)
        {
            var message = new Message
            {
                To = Node.Parse(to),
                Content = CreatePlainTextContent(content)
            };
            return clientChannel.SendMessageAsync(message);
        }

        public Task SendMessageAsync(string content, Node to)
        {
            var message = new Message
            {
                To = to,
                Content = CreatePlainTextContent(content)
            };
            return clientChannel.SendMessageAsync(message);
        }

        public Task SendMessageAsync(Message message)
        {
            return clientChannel.SendMessageAsync(message);
        }

        static PlainText CreatePlainTextContent(string content) => new PlainText { Text = content };
    }
}