using General.CrossCutting.Lib;

using Ligamania.API.Lib.Services;
using Ligamania.Repository;

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

using System;

namespace Ligamania.API.Lib
{
    public static class StartupExtension
    {
        public static void AddAPIStartup(this IServiceCollection services)
        {
            services.AddRepositoryStartup();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            // configure DI for application services
            services.AddScoped<IEquipoService, EquipoService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IEntrenadorService, EntrenadorService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<ICompeticionService, CompeticionService>();
            services.AddScoped<IClubService, ClubService>();
            services.AddScoped<IJugadorService, JugadorService>();
            services.AddScoped<ICalendarioService, CalendarioService>();
            services.AddScoped<IDocumentService, DocumentService>();
            services.AddScoped<IParametrosService, ParametrosService>();
            services.AddScoped<ITemporadaService, TemporadaService>();
        }

        public static void UseAPI(this IApplicationBuilder app)
        {
            app.UseRepository();
        }
    }
}