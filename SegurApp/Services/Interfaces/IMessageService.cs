using SegurApp.Infraestructure.Entities;

namespace SegurApp.Services.Interfaces
{
    public interface IMessageService
    {
        public List<Message> GetMessage();
    }
}
