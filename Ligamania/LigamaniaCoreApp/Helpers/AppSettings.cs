using Microsoft.Extensions.Configuration;

using System;

namespace LigamaniaCoreApp.Helpers
{
    public class AppSettings
    {
        public AppSettings() { }
        public AppSettings(IConfigurationSection configurationSection)
        {
            Secret = configurationSection["Secret"];
            RefreshTokenTTL = Convert.ToInt32(configurationSection["RefreshTokenTTL"]);
            EmailRegistroTo = configurationSection["EmailRegistroTo"];
            EmailFrom = configurationSection["EmailFrom"];
            SmtpHost = configurationSection["SmtpHost"];
            SmtpUser = configurationSection["SmtpUser"];
            SmtpPass = configurationSection["SmtpPass"];
            SubscriptionClientName = configurationSection["SubscriptionClientName"];
            EventBusRetryCount = Convert.ToInt32(configurationSection["EventBusRetryCount"]);
            JornadaMaximaLiga = Convert.ToInt32(configurationSection["JornadaMaximaLiga"]);
            JornadasEliminado = Convert.ToInt32(configurationSection["JornadasEliminado"]);
            MaxVecesEliminado = Convert.ToInt32(configurationSection["MaxVecesEliminado"]);
        }
        public int JornadaMaximaLiga { get; set; }
        public int JornadasEliminado { get; set; }
        public int MaxVecesEliminado { get; set; }

        public string Secret { get; set; }

        // refresh token time to live (in days), inactive tokens are
        // automatically deleted from the database after this time
        public int RefreshTokenTTL { get; set; }

        public string EmailRegistroTo { get; set; }
        public string EmailFrom { get; set; }
        public string SmtpHost { get; set; }
        public int SmtpPort { get; set; }
        public string SmtpUser { get; set; }
        public string SmtpPass { get; set; }
        public string SubscriptionClientName { get; set; }
        public int EventBusRetryCount { get; set; }
    }
}