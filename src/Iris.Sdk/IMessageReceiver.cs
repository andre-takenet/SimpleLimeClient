using Lime.Protocol;
using System.Threading.Tasks;

namespace Iris.Sdk
{
    public interface IMessageReceiver
    {
        Task ReceiveAsync(Message message);
    }
}