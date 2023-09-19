namespace SegurApp.Domain.Dto
{
    public class SendMessageUserDto
    {
        public int EmisorId { get; set; }
        public string Message { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
