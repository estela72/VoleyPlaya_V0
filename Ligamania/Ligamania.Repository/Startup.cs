using General.CrossCutting.Lib;

using Ligamania.Repository.Interfaces;
using Ligamania.Repository.Repositories;
using Ligamania.Repository.Services;

//using Ligamania.Repository.Services;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

using System;

namespace Ligamania.Repository
{
    public static class StartupExtension
    {
        public static void AddRepositoryStartup(this IServiceCollection services)
        {
            // configure DI for DBContext
            services.AddDbContext<LigamaniaDbContext>();

            services.AddIdentity<LigamaniaApplicationUser, IdentityRole>(options =>
                {
                    options.User.AllowedUserNameCharacters = string.Empty;  // permitir todos los caracteres
                    options.SignIn.RequireConfirmedAccount = false;
                })
                .AddEntityFrameworkStores<LigamaniaDbContext>()
                .AddDefaultTokenProviders();

            services.TryAddScoped<ApplicationUserManager<LigamaniaApplicationUser>>();
            services.TryAddScoped<SignInManager<LigamaniaApplicationUser>>();
            services.TryAddScoped<RoleManager<IdentityRole>>();

            //Password Strength Setting
            services.Configure<IdentityOptions>(options =>
            {
                // Password settings
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.Password.RequiredUniqueChars = 0;

                // Lockout settings
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(480);
                options.Lockout.MaxFailedAccessAttempts = 10;
                options.Lockout.AllowedForNewUsers = true;

                // User settings
                //options.User.RequireUniqueEmail = true;
                // User settings.
                //options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+ ";
                options.User.RequireUniqueEmail = false;
            });

            // configure DI for repository
            services.AddScoped<IEquipoRepository, EquipoRepository>()
                    .AddScoped<ICompeticionRepository, CompeticionRepository>()
                    .AddScoped<ICompeticionCategoriaRepository, CompeticionCategoriaRepository>()
                    .AddScoped<ICategoriaRepository, CategoriaRepository>()
                    .AddScoped<IClubRepository, ClubRepository>()
                    .AddScoped<IJugadorRepository, JugadorRepository>()
                    .AddScoped<ICalendarioRepository, CalendarioRepository>()
                    .AddScoped<ICalendarioDetalleRepository, CalendarioDetalleRepository>()
                    .AddScoped<IDocumentsRepository, DocumentsRepository>()
                    .AddScoped<ISettingsRepository, SettingsRepository>()
                    .AddScoped<ITemporadaRepository, TemporadaRepository>()
                    .AddScoped<ITemporadaCompeticionRepository, TemporadaCompeticionRepository>()
                    .AddScoped<ITemporadaJugadorRepository, TemporadaJugadorRepository>()
                    .AddScoped<IPuestoRepository, PuestoRepository>()
                    .AddScoped<IHistoricoRepository, HistoricoRepository>()
                    .AddScoped<ITemporadaContabilidadRepository, TemporadaContabilidadRepository>()
                    .AddScoped<ITemporadaPremiosRepository, TemporadaPremiosRepository>()
                    .AddScoped<ITemporadaPremiosPuestoRepository, TemporadaPremiosPuestoRepository>()
                    .AddScoped<IAlineacionRepository, AlineacionRepository>()
                    ;
            
            // configure DI for UnitOfWork
            services.AddScoped<ILigamaniaUnitOfWork, LigamaniaUnitOfWork>();
        }

        public static void UseRepository(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<LigamaniaDbContext>();
                if (context != null && context.Database != null)
                {
                    context.Database.Migrate();
                }
            }
        }
    }
}