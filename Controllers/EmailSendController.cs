using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StoneStore.Utility.EmailService;

namespace StoneStore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmailSendController : Controller
    {
        private readonly IEmailSender _emailSender;

        public EmailSendController(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }

        [HttpGet]
        public async Task SendEmail()
        {
            var message = new Message(new string[] { "@mail.ru" }, "Test email async", "This is the content from our async email.", "12345678");
            await _emailSender.SendEmailAsync(message);
        }
    }
}