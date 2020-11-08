namespace Application.Users.Registration.Models
{
    public class RegisteredUserDto
    {
        public RegisteredUserDto(string username)
        {
            Username = username;
        }

        public string Username { get; }
    }
}
