using Iris.Sdk;
using System;
using System.Threading.Tasks;

namespace SampleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            var endpoint = "iris.msging.net";
            var client = new IrisClient(endpoint)
                            .UsingAccount("omni", "123456")
                            //.WithOptions(o =>
                            //{
                            //    o.Connection.Timeout = TimeSpan.FromSeconds(10);
                            //    o.Connection.PingInterval = TimeSpan.FromMinutes(5);
                            //    o.Messages.InputQueueSize = 10;
                            //})
                            .AddMessageReceiver(new DefaultMessageReceiver(), forMimeType: MediaTypes.PlainText);
            var execution = client.StartAsync().Result;

            client.SendMessageAsync("Hello, world", "user").Wait();

            Console.WriteLine("Press any key to stop");
            var endingTask = Task.WhenAny(execution, WaitKeyAsync()).Result;
            if (endingTask != execution)
            {
                client.StopAsync().Wait();
            }
        }

        static Task<char> WaitKeyAsync()
        {
            var tcs = new TaskCompletionSource<char>();
            Task.Run(() =>
            {
                var key = Console.ReadKey(false);
                tcs.SetResult(key.KeyChar);
            });
            return tcs.Task;
        }
    }
}
