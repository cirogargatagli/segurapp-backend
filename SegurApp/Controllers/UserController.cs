using Microsoft.AspNetCore.Mvc;
using SegurApp.Infraestructure.Entities;
using SegurApp.Services.Interfaces;

namespace SegurApp.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService) 
        {
            _userService = userService;         
        }

        [HttpGet]
        public List<User> GetAll() 
        {
            return _userService.GetAll();
        }
    }
}
