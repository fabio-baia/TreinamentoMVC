using System;
using Microsoft.AspNet.SignalR;

namespace Treinamento.Hubs
{
    public class ChatHub : Hub
    {
        public void Send(string name, string message)
        {
            var date = DateTime.Now.ToString("T");
            Clients.All.broadcastMessage(name, message, date);
        }
    }
}