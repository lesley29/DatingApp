namespace Application.Users.Login.Models
{
    public class LoggedInUserDto
    {
        public LoggedInUserDto(int id, string username)
        {
            Id = id;
            Username = username;
        }

        public int Id { get; }

        public string Username { get; }
    }
}
