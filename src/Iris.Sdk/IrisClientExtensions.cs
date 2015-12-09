using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Iris.Sdk
{
    public static class IrisClientExtensions
    {
        public static Task SendMessageAsync(this IrisClient client, string content, string to) => client.MessageSender.SendMessageAsync(content, to);
    }
}
