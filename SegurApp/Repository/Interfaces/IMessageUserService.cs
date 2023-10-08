using SegurApp.Domain.Dto;
using SegurApp.Infraestructure.Entities;

namespace SegurApp.Repository.Interfaces
{
    public interface IMessageUserRepository
    {
        void Add(int emisorId, int messageId, double latitude, double longitude, DateTime occurredAt);
        List<MessageUsers> GetAllMessage();
    }
}
