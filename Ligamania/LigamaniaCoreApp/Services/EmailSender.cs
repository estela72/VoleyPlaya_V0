using LigamaniaCoreApp.Helpers;

using MailKit.Net.Smtp;
using MailKit.Security;

using Microsoft.Extensions.Options;

using MimeKit;
using MimeKit.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LigamaniaCoreApp.Services
{
    // This class is used by the application to send email for account confirmation and password reset.
    // For more details see https://go.microsoft.com/fwlink/?LinkID=532713
    public class EmailSender : IEmailSender
    {
        private readonly AppSettings _appSettings;

        public EmailSender(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }
        public EmailSender(AppSettings appSettings)
        {
            _appSettings = appSettings;
        }
        public async Task Send(string to, string subject, string html, string from = null)
        {
            // create message
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(from ?? _appSettings.EmailFrom));
            //to = "egonzalez72@gmail.com";
            email.To.Add(MailboxAddress.Parse(to));
            email.Subject = subject;
            email.Body = new TextPart(TextFormat.Html) { Text = html };

            // send email
            using (var smtp = new SmtpClient())
            {
                await smtp.ConnectAsync(_appSettings.SmtpHost, _appSettings.SmtpPort, SecureSocketOptions.Auto).ConfigureAwait(false);
                await smtp.AuthenticateAsync(_appSettings.SmtpUser, _appSettings.SmtpPass).ConfigureAwait(false);
                await smtp.SendAsync(email).ConfigureAwait(false);
                await smtp.DisconnectAsync(true).ConfigureAwait(false);
            }
        }

        public async Task SendRegistrationEmail(string subject, string html, string from = null)
        {
            // create message
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(from ?? _appSettings.EmailFrom));
            email.To.Add(MailboxAddress.Parse(_appSettings.EmailRegistroTo));
            email.Subject = subject;
            email.Body = new TextPart(TextFormat.Html) { Text = html };

            // send email
            using (var smtp = new SmtpClient())
            {
                await smtp.ConnectAsync(_appSettings.SmtpHost, _appSettings.SmtpPort, SecureSocketOptions.Auto).ConfigureAwait(false);
                await smtp.AuthenticateAsync(_appSettings.SmtpUser, _appSettings.SmtpPass).ConfigureAwait(false);
                await smtp.SendAsync(email).ConfigureAwait(false);
                await smtp.DisconnectAsync(true).ConfigureAwait(false);
            }
        }
    }
}
