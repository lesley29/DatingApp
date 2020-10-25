using System.Threading.Tasks;

namespace Application.Users.Registration
{
    public interface IUserRegistrationService
    {
        Task Register(UserRegistrationRequest request);
    }
}
