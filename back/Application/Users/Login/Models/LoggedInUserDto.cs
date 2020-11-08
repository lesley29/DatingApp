namespace Application.Users.Login.Models
{
    public class LoggedInUserDto
    {
        public LoggedInUserDto(string username)
        {
            Username = username;
        }

        public string Username { get; }
    }
}
