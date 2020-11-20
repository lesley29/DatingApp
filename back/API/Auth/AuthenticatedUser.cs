using System.Security.Claims;
using Application.Users;

namespace API.Auth
{
    public class AuthenticatedUser : IAuthenticatedUser
    {
        public AuthenticatedUser(ClaimsPrincipal user)
        {
            Username = user.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        public string Username { get; }
    }
}
