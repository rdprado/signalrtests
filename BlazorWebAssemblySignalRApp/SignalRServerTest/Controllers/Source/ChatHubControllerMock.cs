using Microsoft.AspNetCore.SignalR;
using SignalRServerTest.Hubs;
using System.Threading;
using System.Threading.Tasks;

namespace SignalRServerTest.Controllers.Source
{
    public class ChatHubControllerMock : ChatHubController
    {
        private readonly IHubContext<ChatHub> _hubContext;

        Task t = null;

        public ChatHubControllerMock(IHubContext<ChatHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public void StartSendingServerMessages(int maximumMessages)
        {
            int counter = 0;
            if (t == null)
            {
                t = new Task(() =>
                {
                    while (counter++ < maximumMessages)
                    {
                        _hubContext.Clients.All.SendAsync("ReceiveServerMessage", counter);
                    }

                    t = null;
                });
                t.Start();
            }
        }

        public void StartSendingServerMessagesWithInterval(int intervalInMilliSecs, int maxMessages)
        {
            int counter = 0;
            if (t == null)
            {
                t = new Task(() =>
                {
                    while (counter++ < maxMessages)
                    {
                        Thread.Sleep(intervalInMilliSecs);
                        _hubContext.Clients.All.SendAsync("ReceiveServerMessage", counter);
                    }
                    t = null;
                });
                t.Start();
            }
        }
    }
}
