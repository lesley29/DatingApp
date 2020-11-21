using System.Reflection;
using Application.Users.Login;
using Application.Users.Registration;
using MapsterMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class ApplicationExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddScoped<IMapper, Mapper>();

            return services
                .AddScoped<IUserRegistrationService, UserRegistrationService>()
                .AddScoped<IUserLoginService, UserLoginService>();
        }
    }
}
