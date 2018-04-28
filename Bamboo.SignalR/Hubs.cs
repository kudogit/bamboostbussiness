using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bamboo.SignalR
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

        public async Task SendMessageToUserId(string userId, string userName, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage/"+ userId, userName, message);
        }

    }


}
