using ClickerGameMVC.Service.Abstract;
using System.Net;
using System.Net.Mail;

namespace ClickerGameMVC.Service.Service
{
    public class EmailService : IEmailService
    {
        public Task SendEmailAsync(string email, string subject, string message)
        {
            var client = new SmtpClient("smptp.office365.com", 587)
            {
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("UnitionConnect@gmail.com", "13246525463180_Unition.")
            };

            return client.SendMailAsync(
                new MailMessage("UnitionConnect@gmail.com", "talhagamga@gmail.com", "Test", "Test"));
        }
    }
}
