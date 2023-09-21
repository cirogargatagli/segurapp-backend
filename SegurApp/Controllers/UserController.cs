using Microsoft.AspNetCore.Mvc;
using SegurApp.Infraestructure.Entities;
using SegurApp.Services.Interfaces;

namespace SegurApp.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService) 
        {
            _userService = userService;         
        }

        [HttpGet("all")]
        public List<User> GetAll() 
        {
            return _userService.GetAll();
        }

        [HttpGet]
        public User GetById([FromQuery] Domain.QueryParameters queryParameters)
        {
            return _userService.GetById(queryParameters);
        }
    }
}
