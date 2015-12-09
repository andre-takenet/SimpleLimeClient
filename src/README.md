**This is a proof of concept (work is in progress)**

Simple [Lime Protocol](http://github.com/takenet/lime-csharp/) client with a fluent-style construction.

All you need is:

```c#
var client = new IrisClient("server.limeprotocol.org")
                .UsingAccount("myaccount", "mypassword")
                .AddReceiver(new DefaultMessageReceiver());

var executionTask = client.StartAsync();
```
    
And `DefaultMessageReceiver` class could be as simple as:

```c#
class DefaultMessageReceiver : MessageReceiverBase
{
    public async override Task ReceiveAsync(Message message)
    {
        Trace.WriteLine(message.Content.ToString());
        await Sender.SendMessageAsync("Thanks for you message");
    }
}
```
