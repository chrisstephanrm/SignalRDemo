using System.Threading.Tasks;
using SignalrDemo.Models;

namespace SignalrDemo.Signalr
{
    public interface IHubClient
    {
        Task BroadcastMessage(MessageInstance msg);
    }
}