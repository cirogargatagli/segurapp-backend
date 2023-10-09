using Microsoft.AspNetCore.Mvc;
using SegurApp.Infraestructure.Entities;
using SegurApp.Services.Interfaces;

namespace SegurApp.Controllers
{
    [Route("api/message")]
    public class MessageController : Controller
    {
        private readonly IMessageService _messageService;

        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        /// <summary>
        /// Filtrar todos los mensajes 
        /// </summary>
        [HttpGet]
        public List<Message> GetMessages()
        {
            try
            {
                return _messageService.GetMessage();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
