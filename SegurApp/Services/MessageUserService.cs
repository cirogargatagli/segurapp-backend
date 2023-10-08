using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SegurApp.Domain.Dto;
using SegurApp.Infraestructure.Entities;
using SegurApp.Repository.Interfaces;
using SegurApp.Services.Hubs;
using SegurApp.Services.Interfaces;

namespace SegurApp.Services
{
    public class MessageUserService : IMessageUserService
    {
        private readonly IMessageUserRepository _messageUserRepository;
        private readonly IMessageRepository _messageRepository;
        private readonly IUserRepository _userRepository;
        private readonly IHubContext<SendMessageHub> _hubContext;



        public MessageUserService(IMessageUserRepository messageUserRepository, IMessageRepository messageRepository, IUserRepository userRepository, IHubContext<SendMessageHub> hubContext) 
        {
            _messageUserRepository = messageUserRepository;
            _messageRepository = messageRepository;
            _userRepository = userRepository;
            _hubContext = hubContext;
        }

        public void SendMessageUser(SendMessageUserDto sendMessageUserDto)
        {
            User emisor = _userRepository.GetById(sendMessageUserDto.EmisorId);
            _hubContext.Clients.All.SendAsync("ReceiveMessage", sendMessageUserDto.Message, emisor, sendMessageUserDto.Latitude, sendMessageUserDto.Longitude, sendMessageUserDto.OccurredAt);
            _messageUserRepository.Add(sendMessageUserDto.EmisorId, sendMessageUserDto.Message.Id, sendMessageUserDto.Latitude, sendMessageUserDto.Longitude, sendMessageUserDto.OccurredAt);
        }       

        public List<MessageUsers> GetAllMessage()
        {
            List<MessageUsers> messageUsers = new List<MessageUsers>();

            messageUsers = _messageUserRepository.GetAllMessage();

            return messageUsers;
        }
    }
}
