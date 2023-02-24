using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LigamaniaCoreApp.Services
{
    public interface IEmailSender
    {
        Task Send(string to, string subject, string html, string from = null);
        Task SendRegistrationEmail(string subject, string html, string from = null);
    }
}
