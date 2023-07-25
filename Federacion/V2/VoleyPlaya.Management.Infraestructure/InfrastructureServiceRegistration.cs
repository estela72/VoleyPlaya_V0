using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VoleyPlaya.Management.Application.Contracts.Persistence;
using VoleyPlaya.Management.Infraestructure.Persistence;
using VoleyPlaya.Management.Infraestructure.Repositories;

namespace VoleyPlaya.Management.Infraestructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<VoleyPlayaManagementContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("Development"))
            );

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));

            services.AddScoped<IEdicionGrupoRepository, EdicionGrupoRepository>();
            services.AddScoped<IEdicionRepository, EdicionRepository>();
            services.AddScoped<IJornadaRepository, JornadaRepository>();
            services.AddScoped<IPartidoRepository, PartidoRepository>();

            return services;
        }
    }
}
