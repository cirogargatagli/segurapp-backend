using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SegurApp.Domain.Dto;
using SegurApp.Infraestructure.Entities;
using SegurApp.Services.Interfaces;
using SegurAppJWToken.JWToken.Interfaces;
using SegurApp.Validations;

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
            var user =  _userService.GetAll();

            return user.ToList();
        }

        [HttpGet("id")]
        [Authorize]
        public User GetById([FromQuery] Domain.QueryParameters queryParameters)
        {
            return _userService.GetById(queryParameters);
        }

        [HttpPost("create")]
        public ActionResult CreateUser([FromBody]RequestCreateUser createUser)
        {
            if (!Validations.Validations.IsValidName(createUser.FullName))
            {
                return BadRequest("Nombre no válido");
            }

            if (!Validations.Validations.IsValidDni(createUser.Dni))
            {
                return BadRequest("DNI no válido");
            }

            if (!Validations.Validations.IsValidEmail(createUser.Email))
            {
                return BadRequest("Email no válido");
            }

            if (!Validations.Validations.IsValidPhoneNumber(createUser.Phone))
            {
                return BadRequest("Teléfono no válido");
            }

            if (!Validations.Validations.IsValidPassword(createUser.Password))
            {
                return BadRequest("Contraseña no válida, debe tener al menos 8 caracteres, una letra mayuscula y un numero");
            }

            User user = _userService.CreateUser(createUser.FullName, createUser.Dni, createUser.Email, createUser.Phone, createUser.Password);

            return new JsonResult(new { User = user, Message = "Usuario creado con exito" }) { StatusCode = 201 };
        }

        [HttpPost("Login")]
        public ActionResult<ResponseLogin> LoginUser([FromBody]RequestLogin requestLogin)
        {
            User user = _userService.LoginUser(requestLogin.User, requestLogin.Password);

            if (user == null)
            {
                return new JsonResult(new ResponseLogin { Jwt = null, Message = "Usuario o password incorrectos" }) { StatusCode = 400 };
            }
            string jwt = _tokenManejo.GenerateToken(user);

            return new JsonResult(new ResponseLogin { Jwt = jwt, Message = "OK"}) { StatusCode = 200};
        }

        [HttpDelete("delete")]
        public IActionResult DeleteUser(int id)
        {
            _userService.DeleteUser(id);

            return new JsonResult(new { Message = "Usuario eliminado con éxito" }) { StatusCode = 200 };
        }
    }
}
