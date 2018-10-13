using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using SignalrDemo.Models;

namespace SignalrDemo.Signalr
{
    public class SignalrHub : Hub<IHubClient>
    {
        public async Task BroadcastMessage(MessageInstance msg)
        {
            await Clients.All.BroadcastMessage(msg);
        }
    }
}