using AutoMapper;

using Microsoft.Extensions.DependencyInjection;

using Newtonsoft.Json.Schema;

using VoleyPlaya.Domain.Services;
using VoleyPlaya.Repository;

namespace VoleyPlaya.Domain
{
    public static class Startup
    {
        public static void AddDomainStartup(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddScoped<IEdicionService, EdicionService>();
            services.AddRepositoryStartup();
        }
    }
}