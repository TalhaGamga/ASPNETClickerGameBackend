namespace ClickerGameMVC.Service.Abstract
{
    public interface IEmailService
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
