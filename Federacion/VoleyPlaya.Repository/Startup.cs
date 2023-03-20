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

namespace VoleyPlaya.Repository
{
    public static class StartupExtension
    {
        public static void AddRepositoryStartup(this IServiceCollection services)
        {
            // configure DI for DBContext
            services.AddDbContext<VoleyPlayaDbContext>();

            // configure DI for Repositories
            services.AddScoped<ICategoriaRepository, CategoriaRepository>();
            services.AddScoped<ICompeticionRepository, CompeticionRepository>();
            services.AddScoped<IEdicionRepository, EdicionRepository>();
            services.AddScoped<IEquipoRepository, EquipoRepository>();
            services.AddScoped<IParcialPartidoRepository, ParcialPartidoRepository>();
            services.AddScoped<IPartidoRepository, PartidoRepository>();
            services.AddScoped<ITemporadaRepository, TemporadaRepository>();

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