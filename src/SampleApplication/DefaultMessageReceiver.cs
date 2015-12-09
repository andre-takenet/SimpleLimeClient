using System;
using System.Threading.Tasks;
using Iris.Sdk;
using Lime.Protocol;

namespace SampleApplication
{
    class DefaultMessageReceiver : MessageReceiverBase
    {
        public async override Task ReceiveAsync(Message message)
        {
            Console.WriteLine(message.Content.ToString());
            await Sender.SendMessageAsync("Obrigado pela sua mensagem", message.From.Name);
        }
    }
}