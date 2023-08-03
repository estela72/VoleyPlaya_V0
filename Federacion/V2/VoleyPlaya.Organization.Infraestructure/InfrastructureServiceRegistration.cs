using GenericLib;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VoleyPlaya.Organization.Application.Contracts.Persistence;
using VoleyPlaya.Organization.Infraestructure.Persistence;
using VoleyPlaya.Organization.Infraestructure.Repositories;

namespace VoleyPlaya.Organization.Infraestructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<VoleyPlayaOrganizationContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("Development"))
            );

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUnitOfWorkOrganization, UnitOfWorkOrganization>();
            services.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));

            services.AddScoped<ITemporadaRepository, TemporadaRepository>();
            services.AddScoped<ITablaRepository, TablaRepository>();
            services.AddScoped<IEquipoRepository, EquipoRepository>();
            services.AddScoped<ICompeticionRepository, CompeticionRepository>();
            services.AddScoped<ICategoriaRepository, CategoriaRepository>();

            return services;
        }
    }
}
