using MailKit.Net.Smtp;
using MailKit.Security;

using Microsoft.Extensions.Configuration;

using MimeKit;
using MimeKit.Text;

using System.Threading.Tasks;

namespace General.CrossCutting.Lib
{
#pragma warning disable CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
    public interface IEmailService
#pragma warning restore CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
    {
#pragma warning disable CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
        Task Send(string to, string subject, string html, string from = null);
#pragma warning restore CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
    }

#pragma warning disable CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
    public class EmailService : IEmailService
#pragma warning restore CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
    {
        private readonly IConfiguration _configuration;

#pragma warning disable CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
        public EmailService(IConfiguration configuration)
#pragma warning restore CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
        {
            _configuration = configuration;
        }

#pragma warning disable CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
        public async Task Send(string to, string subject, string html, string from = null)
#pragma warning restore CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
        {
            // create message
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(from ?? _configuration["Email:EmailFrom"]));
            email.To.Add(MailboxAddress.Parse(to));
            email.Subject = subject;
            email.Body = new TextPart(TextFormat.Html) { Text = html };

            // send email
            using var smtp = new SmtpClient();
            await smtp.ConnectAsync(_configuration["Email:SmtpHost"], int.Parse(_configuration["Email:SmtpPort"]), SecureSocketOptions.Auto);
            await smtp.AuthenticateAsync(_configuration["Email:SmtpUser"], _configuration["Email:SmtpPass"]);
            await smtp.SendAsync(email);
            await smtp.DisconnectAsync(true);
        }
    }
}