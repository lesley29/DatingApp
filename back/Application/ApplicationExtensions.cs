using Application.Users.Login;
using Application.Users.Registration;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class ApplicationExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            return services
                .AddScoped<IUserRegistrationService, UserRegistrationService>()
                .AddScoped<IUserLoginService, UserLoginService>();
        }
    }
}
