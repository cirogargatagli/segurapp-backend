using SegurApp.Infraestructure.Entities;
using SegurApp.Repository.Interfaces;
using SegurApp.Services.Interfaces;

namespace SegurApp.Services
{
    public class MessageService : IMessageService
    {
        IMessageRepository _messageRepository;

        public MessageService(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }
        public List<Message> GetMessage()
        {
            return _messageRepository.GetAll();
        }
    }
}
