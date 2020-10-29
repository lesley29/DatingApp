using System.Threading.Tasks;

namespace Application.Users.Login
{
    public interface IUserLoginService
    {
        Task<UserDto?> Login(UserLoginRequest request);
    }
}
