using SegurApp.Infraestructure;
using SegurApp.Infraestructure.Entities;
using SegurApp.Repository.Interfaces;

namespace SegurApp.Repository
{
    public class MessageRepository : IMessageRepository
    {
        private readonly Context _context;

        public MessageRepository(Context context)
        {
            _context = context;
        }

        public Message GetById(int id)
        {
            return _context.Messages.Where(x => x.Id == id).FirstOrDefault();
        }

        public Message GetByDescription(string description)
        {
            return _context.Messages.Where(x => x.Description.ToUpper() == description.ToUpper()).FirstOrDefault();
        }
    }
}
