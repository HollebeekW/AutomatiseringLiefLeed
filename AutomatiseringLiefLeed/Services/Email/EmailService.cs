using System.Net.Mail;
using System.Net;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace AutomatiseringLiefLeed.Services.Email
{
    public interface IEmailService
    {
        void SendEmail(string email, string subject, string body);
        void SendApplicationSubmittedEmail(string to, string recipient, string reason, string dateOfApplication);
        void SendApplicationApprovedEmail(string to, string recipient, string reason, string dateOfApplication);
        void SendApplicationRejectedEmail(string to, string recipient, string reason, string dateOfApplication);
    }

    public class EmailService : IEmailService
    {

        private readonly SmtpSettings _settings;

        public EmailService(IOptions<SmtpSettings> options)
        {
            _settings = options.Value;
        }

        public void SendEmail(string  to, string subject, string body)
        {
            var message = new MailMessage(_settings.FromEmail, to, subject, body);

            using var client = new SmtpClient(_settings.Host, _settings.Port)
            {
                Credentials = new NetworkCredential(_settings.Username, _settings.Password),
                EnableSsl = _settings.EnableSsl
            };

            client.Send(message);
        }

        public void SendApplicationSubmittedEmail(string to, string recipient, string reason, string dateOfApplication)
        {
            var subject = "Aanvraagd succesvol ingediend";
            var body = $"De aanvraag voor {recipient} met reden {reason} is op {dateOfApplication} succesvol ingediend!"; 
            SendEmail(to, subject, body);
        }

        public void SendApplicationApprovedEmail(string to, string recipient, string reason, string dateOfApplication)
        {
            var subject = "Aanvraag goedgekeurd";
            var body = $"De aanvraag die op {dateOfApplication} is ingediend voor {recipient} met als reden {reason} is goedgekeurd";
            SendEmail(to, subject, body);
        }

        public void SendApplicationRejectedEmail(string to, string recipient, string reason, string dateOfApplication)
        {
            var subject = "Aanvraag afgekeurd";
            var body = $"De aanvraag die op {dateOfApplication} is ingediend voor {recipient} met als reden {reason} is afgekeurd";
            SendEmail(to, subject, body);
        }
    }
}