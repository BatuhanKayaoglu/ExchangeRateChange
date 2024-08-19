using ExchangeRateChange.Common.Hubs;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRateConsumeService
{
    public class SignalrService
    {
        private readonly IHubContext<ExchangeRateHub> _hubContext;

        public SignalrService(IHubContext<ExchangeRateHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public async Task SendMessageToClient(string user, string message)
        {
            await _hubContext.Clients.All.SendAsync("ReceiveMessage", user, message);
        }   
    }
}
