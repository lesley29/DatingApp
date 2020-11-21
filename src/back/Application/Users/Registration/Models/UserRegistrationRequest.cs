namespace Application.Users.Registration.Models
{
    public class UserRegistrationRequest
    {
        public string UserName { get; set; } = null!;

        public string Password { get; set; } = null!;
    }
}
