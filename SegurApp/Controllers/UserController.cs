using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SegurApp.Infraestructure.Entities;
using SegurApp.Services.Interfaces;
using SegurAppJWToken.JWToken.Interfaces;

namespace SegurApp.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IJWTokenManejo _tokenManejo;

        public UserController(IUserService userService, IJWTokenManejo tokenManejo)
        {
            _userService = userService;
            _tokenManejo = tokenManejo;
        }

        [HttpGet("all")]
        [Authorize]
        public List<User> GetAll() 
        {
            return _userService.GetAll();
        }

        [HttpGet]
        public User GetById([FromQuery] Domain.QueryParameters queryParameters)
        {
            string jwt = _tokenManejo.GenerateToken("leandrolima@gmail.com");
            return _userService.GetById(queryParameters);
        }
    }
}
