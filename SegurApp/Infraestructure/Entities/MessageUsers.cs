namespace SegurApp.Infraestructure.Entities
{
    public class MessageUsers
    {
        public int Id { get; set; }
        public DateTime OccurredAt { get; set; }
        public int ReceptorId { get; set; }

        public int EmisorId { get; set; }
        public int MessageId { get; set; }

        public Message Message { get; set; }
        public User Emisor { get; set; }
        public User Receptor { get; set; }
    }
}
