using Domain.Aggregates.User.Entities;

namespace Application.Common.Identity
{
    public interface ITokenService
    {
        string Generate(User user);
    }
}
