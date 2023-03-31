namespace StoneStore.Utility.EmailService
{
    public interface IEmailSender
    {
        void SendEMail(Message message);
    }
}