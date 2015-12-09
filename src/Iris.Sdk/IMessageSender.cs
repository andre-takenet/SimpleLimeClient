using Lime.Protocol;
using System.Threading.Tasks;

namespace Iris.Sdk
{
    public interface IMessageSender
    {
        Task SendMessageAsync(Message message);
        Task SendMessageAsync(string content);
    }
}