using System.Net.Mail;
using System.Net;
using Microsoft.Extensions.Options;

namespace AutomatiseringLiefLeed.Services.Email
{
    public interface IEmailService
    {
        void SendEmail(string to, string subject, string body);
    }

    public class EmailService : IEmailService
    {
        private readonly SmtpSettings _settings;

        public EmailService(IOptions<SmtpSettings> smtpOptions)
        {
            _settings = smtpOptions.Value;
        }

        public void SendEmail(string to, string subject, string body)
        {
            var message = new MailMessage(_settings.FromEmail, to, subject, body);

            using var client = new SmtpClient(_settings.Host, _settings.Port)
            {
                Credentials = new NetworkCredential(_settings.Username, _settings.Password),
                EnableSsl = _settings.EnableSsl,
            };

            client.Send(message);
        }
    }

}