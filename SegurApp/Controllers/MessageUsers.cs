using Microsoft.AspNetCore.Mvc;
using SegurApp.Domain.Dto;
using SegurApp.Infraestructure.Entities;
using SegurApp.Services;
using SegurApp.Services.Interfaces;

namespace SegurApp.Controllers
{
    [Route("api/message-users")]
    [ApiController]
    public class MessageUserController : Controller
    {
        private readonly IMessageUserService _messageUserService;

        public MessageUserController(IMessageUserService messageUserService)
        {
            _messageUserService = messageUserService;
        }

        ///<summary>
        /// Envio de mensajes 
        /// </summary>
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

        ///<summary>
        /// Filtrar todos los Mensajes 
        /// </summary>
        [HttpGet]
        public List<MessageUsers> GetAllMessages()
        {
            try
            {
                return _messageUserService.GetAllMessage();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
