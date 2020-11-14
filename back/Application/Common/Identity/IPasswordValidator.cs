using Domain.Aggregates.User.ValueObjects;

namespace Application.Common.Identity
{
    public interface IPasswordValidator
    {
        bool Validate(string enteredPassword, Password correctPassword);
    }
}
