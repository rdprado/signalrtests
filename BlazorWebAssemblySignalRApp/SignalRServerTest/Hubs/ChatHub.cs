using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.Connections.Features;
using Microsoft.AspNetCore.SignalR;
using SignalRServerTest.Controllers;

namespace SignalRServerTest.Hubs
{
    public class ChatHub : Hub
    {
        ChatHubController controller;

        public ChatHub(ChatHubController controller)
        {
            this.controller = controller;
        }

        public override async Task OnConnectedAsync()
        {
            Console.WriteLine($" Client connected with transport type: {Context.Features.Get<IHttpTransportFeature>().TransportType}");

            await base.OnConnectedAsync();
        }

        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

        public void StartSendingServerMessages(int msInterval)
        {
            controller.StartSendingServerMessages(msInterval);
        }
    }
}