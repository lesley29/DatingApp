namespace Application.Users.Registration.Models
{
    public class RegisteredUserDto
    {
        public RegisteredUserDto(int userId, string username)
        {
            UserId = userId;
            Username = username;
        }

        public int UserId { get; }

        public string Username { get; }
    }
}
