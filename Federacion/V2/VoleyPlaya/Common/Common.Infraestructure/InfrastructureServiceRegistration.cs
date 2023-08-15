using Common.Application.Contracts.Persistence;
using Common.Infraestructure.Persistence;
using Common.Infraestructure.Repositories;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Common.Infraestructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddCommonInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<GenericDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("Development"))
            );

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));

            return services;
        }
    }
}
