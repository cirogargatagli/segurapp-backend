using Microsoft.AspNetCore.SignalR;
using SegurApp.Domain.Dto;
using SegurApp.Infraestructure.Entities;

namespace SegurApp.Services.Hubs
{
    public class SendMessageHub : Hub
    {
        public async Task SendMessage(Message message, User emisor)
        {
            await Clients.All.SendAsync("ReceiveMessage", message, emisor);
        }
    }
}
