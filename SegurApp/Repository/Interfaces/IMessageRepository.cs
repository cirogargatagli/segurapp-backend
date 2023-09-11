using SegurApp.Infraestructure.Entities;

namespace SegurApp.Repository.Interfaces
{
    public interface IMessageRepository
    {
        Message GetById(int id);
    }
}
