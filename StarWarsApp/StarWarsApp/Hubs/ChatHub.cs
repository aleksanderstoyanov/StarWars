using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace StarWarsApp.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string username, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", username, message);
        }
    }
}
