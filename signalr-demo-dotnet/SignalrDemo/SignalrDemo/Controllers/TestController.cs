using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using MsgPack;
using SignalrDemo.Models;
using SignalrDemo.Signalr;

namespace SignalrDemo.Controllers
{
    [Route("api/Test")]
    public class TestController : Controller
    {
        private IHubContext<SignalrHub, IHubClient> _signalrHub;

        public TestController(IHubContext<SignalrHub, IHubClient> signalrHub)
        {
            _signalrHub = signalrHub;
        }
        
        [HttpPost]
        public async Task<string> Post([FromBody]MessageInstance msg)
        {
            var retMessage = string.Empty;
            try
            {
                msg.Timestamp = Timestamp.UtcNow.ToString();
                await _signalrHub.Clients.All.BroadcastMessage(msg);
                retMessage = "Success";
            }
            catch (Exception e)
            {
                retMessage = e.ToString();
            }         
            return retMessage;
        }
    }
}