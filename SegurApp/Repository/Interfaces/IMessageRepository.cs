using SegurApp.Infraestructure.Entities;

namespace SegurApp.Repository.Interfaces
{
    public interface IMessageRepository
    {
        Message GetById(int id);
        Message GetByDescription(string description);
        List<Message> GetAll();
    }
}
