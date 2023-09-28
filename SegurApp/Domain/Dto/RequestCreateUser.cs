using Microsoft.AspNetCore.Mvc;

namespace SegurApp.Domain.Dto
{
    public class RequestCreateUser
    {
        public string FullName { get; set; }
        public string Dni { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
    }
}
