using Microsoft.AspNetCore.Mvc;
using SegurApp.Domain.Dto;
using SegurApp.Infraestructure.Entities;
using SegurApp.Services;
using SegurApp.Services.Interfaces;
using System.Collections.Generic;

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
        public IActionResult GetAllMessages()
        {
            try
            {
                List<MessageUsers> messageUsers = new List<MessageUsers>();

                messageUsers = _messageUserService.GetAllMessage();

                if (messageUsers.Count() == 0)
                {
                    return NotFound(new { Message = "No hay mensajes disponibles." });
                }
                else
                {
                    return Ok(messageUsers);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
