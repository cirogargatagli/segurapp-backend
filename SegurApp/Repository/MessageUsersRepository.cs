using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        public void Add(int emisorId, int messageId, double latitude, double longitude, DateTime occurredAt)
        {
            _context.Add(new MessageUsers
            {
                OccurredAt = occurredAt,
                EmisorId = emisorId,
                MessageId = messageId,
                Latitude = latitude,
                Longitude = longitude
            });
            _context.SaveChanges();
        }

        public List<MessageUsers> GetAllMessage()
        {
            List<MessageUsers> messageUsers = _context.MessagesUsers.Include(e => e.Emisor)
                .Include(e => e.Message).ToList();

            return messageUsers;
        }
    }
}
