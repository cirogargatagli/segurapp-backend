using SegurApp.Infraestructure.Entities;

namespace SegurApp.Domain.Dto
{
    public class SendMessageUserDto
    {
        public int EmisorId { get; set; }
        public MessageDto Message { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public DateTime OccurredAt { get; set; }
    }
}
