using Domain.Entities;

namespace Application.Common
{
    public interface ITokenService
    {
        string Generate(User user);
    }
}
