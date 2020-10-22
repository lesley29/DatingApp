using Application.Persistence;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class InfrastructureExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DatingAppDbContext>(opts =>
            {
                opts.UseNpgsql(configuration.GetConnectionString("Default"));
            });
            services.AddScoped<IDatingAppDbContext>(f => f.GetRequiredService<DatingAppDbContext>());

            return services;
        }
    }
}
