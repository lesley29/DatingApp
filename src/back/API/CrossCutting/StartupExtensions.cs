using API.CrossCutting.UserActivityLogging;
using Microsoft.Extensions.DependencyInjection;

namespace API.CrossCutting
{
    public static class StartupExtensions
    {
        public static IServiceCollection AddCrossCutting(this IServiceCollection services)
        {
            return services.AddScoped<LogUserActivityActionFilter>();
        }
    }
}
