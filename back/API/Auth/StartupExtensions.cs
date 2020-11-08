using Microsoft.AspNetCore.Builder;

namespace API.Auth
{
    public static class StartupExtensions
    {
        public static IApplicationBuilder SetAuthorizationHeaderFromCookies(this IApplicationBuilder app)
        {
            return app.UseMiddleware<AuthorizationHeaderFromCookiesMiddleware>();
        }
    }
}
