using Microsoft.Extensions.DependencyInjection;

using VoleyPlaya.Domain.Services;
using VoleyPlaya.Repository;

namespace VoleyPlaya.Domain
{
    public static class Startup
    {
        public static void AddDomainStartup(this IServiceCollection services)
        {
            services.AddScoped<IEdicionService, EdicionService>();
            services.AddRepositoryStartup();
        }
    }
}