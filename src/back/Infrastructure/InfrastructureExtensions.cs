using Application.Common.Cryptography;
using Application.Common.Identity;
using Application.Persistence;
using Domain.Aggregates.User;
using Infrastructure.Cryptography;
using Infrastructure.Identity;
using Infrastructure.Persistence;
using Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NodaTime;

namespace Infrastructure
{
    public static class InfrastructureExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DatingAppDbContext>(opts =>
            {
                opts.UseNpgsql(configuration.GetConnectionString("Default"), npgsqlOpts => npgsqlOpts.UseNodaTime());
            });

            services.AddScoped<IDatingAppDbContext>(f => f.GetRequiredService<DatingAppDbContext>());
            services.AddRepositories();

            services.AddSingleton<IPasswordHashService, PasswordHashService>();
            services.AddScoped<IPasswordValidator, PasswordValidator>();
            services.AddSingleton<ITokenService, TokenService>();
            services.AddSingleton<IClock>(_ => SystemClock.Instance);

            return services;
        }

        private static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            return services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
