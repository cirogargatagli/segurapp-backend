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
        public List<User> GetAll() 
        {
            return _userService.GetAll();
        }

        [HttpGet]
        [Authorize]
        public User GetById([FromQuery] Domain.QueryParameters queryParameters)
        {
            string jwt = _tokenManejo.GenerateToken("", "", "");
            return _userService.GetById(queryParameters);
        }

        [HttpPost]
        [Authorize]
        public IActionResult CreateUser(string FullName, string Dni, string Email, string Phone, string Password)
        {
            User user = _userService.CreateUser(FullName, Dni, Email, Phone, Password);

            return Ok("Se realizó el alta correctamente");
        }

        [HttpPost("Login")]
        public IActionResult LoginUser(string email, string Password)
        {
            User user = _userService.LoginUser(email, Password);
            if (user == null)
            {
                return BadRequest("User/Pass Incorrecto");
            }
            string jwt = _tokenManejo.GenerateToken(user.Id.ToString(), user.FullName, user.RoleId.ToString());

            return Ok(jwt);
        }
    }
}
