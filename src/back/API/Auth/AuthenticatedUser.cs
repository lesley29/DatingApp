using System.Security.Claims;
using Application.Users;

namespace API.Auth
{
    public class AuthenticatedUser : IAuthenticatedUser
    {
        public AuthenticatedUser(ClaimsPrincipal user)
        {
            Id = int.Parse(user.FindFirstValue(ClaimTypes.NameIdentifier));
            Username = user.FindFirstValue(ClaimTypes.Email);
        }

        public int Id { get; set; }

        public string Username { get; }
    }
}
