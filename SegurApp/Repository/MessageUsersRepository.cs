using SegurApp.Domain.Dto;
using SegurApp.Infraestructure;
using SegurApp.Infraestructure.Entities;
using SegurApp.Repository.Interfaces;

namespace SegurApp.Repository
{
    public class MessageUsersRepository : IMessageUserRepository
    {
        private readonly Context _context;

        public MessageUsersRepository(Context context)
        {
            _context = context;
        }

        public void Add(SendMessageUserDto sendMessageUserDto)
        {
            _context.Add(new MessageUsers
            {
                OccurredAt = DateTime.Now,
                EmisorId = sendMessageUserDto.EmisorId,
                ReceptorId = sendMessageUserDto.ReceptorId,
                MessageId = sendMessageUserDto.MessageId
            });
            _context.SaveChanges();
        }
    }
}
