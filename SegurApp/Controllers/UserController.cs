using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SegurApp.Domain.Dto;
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
            return _userService.GetById(queryParameters);
        }

        [HttpPost]
        public ActionResult CreateUser([FromBody]RequestCreateUser createUser)
        {
            User user = _userService.CreateUser(createUser.FullName, createUser.Dni, createUser.Email, createUser.Phone, createUser.Password);

            return new JsonResult(user) { StatusCode = 201};//Ok("Se realizó el alta correctamente");
        }

        [HttpPost("Login")]
        public ActionResult<ResponseLogin> LoginUser([FromBody]RequestLogin requestLogin)
        {
            User user = _userService.LoginUser(requestLogin.User, requestLogin.Password);
            if (user == null)
            {
                return new JsonResult(new ResponseLogin { Jwt = null, Message = "User/Pass Incorrecto" }) { StatusCode = 400 };
            }
            string jwt = _tokenManejo.GenerateToken(user.Id.ToString(), user.FullName, user.RoleId.ToString());

            return new JsonResult(new ResponseLogin { Jwt = jwt, Message = "OK"}) { StatusCode = 200};
        }
    }
}
