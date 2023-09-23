using SegurApp.Domain.Dto;
using SegurApp.Infraestructure.Entities;

namespace SegurApp.Services.Interfaces
{
    public interface IMessageUserService
    {
        void SendMessageUser(SendMessageUserDto sendMessageUserDto);
        List<MessageUsers> GetAllMessage();        
    }
}
