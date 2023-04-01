using System.Threading.Tasks;

namespace StoneStore.Utility.EmailService
{
    public interface IEmailSender
    {
        Task SendEmailAsync(Message message);
    }
}