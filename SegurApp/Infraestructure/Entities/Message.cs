namespace SegurApp.Infraestructure.Entities
{
    public class Message
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public ICollection<MessageUsers> MessageUsers { get; set; }

    }
}
