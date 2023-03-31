using Microsoft.AspNetCore.Mvc;
using StoneStore.Utility.EmailService;

namespace StoneStore.Controllers
{
    public class EmailSendController : Controller
    {
        private readonly EmailSender _emailSender;

        public EmailSendController(EmailSender emailSender)
        {
            _emailSender = emailSender;
        }

        [HttpGet]
        public IActionResult SendEmail()
        {
            var message = new Message(new string[] { "codemazetest@mailinator.com" }, "Test email async", "This is the content from our async email.", null);
            _emailSender.SendEMail(message);
            
            return Ok();
        }
    }
}