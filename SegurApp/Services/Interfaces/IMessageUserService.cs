using SegurApp.Domain.Dto;

namespace SegurApp.Services.Interfaces
{
    public interface IMessageUserService
    {
        void SendMessageUser(SendMessageUserDto sendMessageUserDto);
    }
}
