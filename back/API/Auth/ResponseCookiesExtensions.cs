using Infrastructure.Identity;
using Microsoft.AspNetCore.Http;

namespace API.Auth
{
    public static class ResponseCookiesExtensions
    {
        public static void SetToken(this IResponseCookies cookies, string jwtToken)
        {
            cookies.Append(IdentityConstant.AccessTokenCookieKey, jwtToken, new CookieOptions
            {
                HttpOnly = true,
                SameSite = SameSiteMode.Strict
            });
        }

        public static void RemoveToken(this IResponseCookies cookies)
        {
            cookies.Delete(IdentityConstant.AccessTokenCookieKey);
        }
    }
}
