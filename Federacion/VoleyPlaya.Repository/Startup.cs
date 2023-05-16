using General.CrossCutting.Lib;

using VoleyPlaya.Repository.Interfaces;
using VoleyPlaya.Repository.Repositories;
using VoleyPlaya.Repository.Services;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

using System;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;

namespace VoleyPlaya.Repository
{
    public static class StartupExtension
    {
        public static void AddRepositoryStartup(this IServiceCollection services)
        { 
            // Add framework services.
            services.AddDbContext<VoleyPlayaDbContext>(
                options => options.ConfigureWarnings(b => b.Log(CoreEventId.ManyServiceProvidersCreatedWarning))
            );
            services.AddDatabaseDeveloperPageExceptionFilter();

            // configure DI for DBContext
            services.AddDbContext<VoleyPlayaDbContext>();

            services.AddDatabaseDeveloperPageExceptionFilter();

            // configure DI for Repositories
            services.AddScoped<ICategoriaRepository, CategoriaRepository>();
            services.AddScoped<ICompeticionRepository, CompeticionRepository>();
            services.AddScoped<IEdicionRepository, EdicionRepository>();
            services.AddScoped<IEquipoRepository, EquipoRepository>();
            services.AddScoped<IParcialPartidoRepository, ParcialPartidoRepository>();
            services.AddScoped<IPartidoRepository, PartidoRepository>();
            services.AddScoped<ITemporadaRepository, TemporadaRepository>();
            services.AddScoped<IJornadaRepository, JornadaRepository>();
            services.AddScoped<IEdicionGrupoRepository, EdicionGrupoRepository>();

            // configure DI for UnitOfWork
            services.AddScoped<IVoleyPlayaUnitOfWork, VoleyPlayaUnitOfWork>();

            // configure DI for Services
            services.AddScoped<IVoleyPlayaService, VoleyPlayaService>();

            // Update Databases when app started
            using (ServiceProvider serviceProvider = services.BuildServiceProvider())
            {
                VoleyPlayaDbContext dbContext = serviceProvider.GetRequiredService<VoleyPlayaDbContext>();
                //dbContext.Database.EnsureDeleted();
                //dbContext.Database.EnsureCreated();
                dbContext.Database.Migrate();
            }
        }
    }
}