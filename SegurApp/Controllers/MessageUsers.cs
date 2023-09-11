using Microsoft.AspNetCore.Mvc;
using SegurApp.Domain.Dto;
using SegurApp.Infraestructure.Entities;
using SegurApp.Services.Interfaces;

namespace SegurApp.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class MessageUserController : Controller
    {
        private readonly IMessageUserService _messageUserService;

        public MessageUserController(IMessageUserService messageUserService)
        {
            _messageUserService = messageUserService;
        }

        [HttpPost]
        public IActionResult SendMessage([FromBody] SendMessageUserDto body)
        {
            try
            {
                _messageUserService.SendMessageUser(body);
                return Ok("Mensaje enviado correctamente");
            }
            catch (Exception)
            {
                return StatusCode(500, "Se produjo un error al enviar el mensaje");
            }
        }
    }
}
