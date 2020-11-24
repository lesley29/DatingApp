namespace Application.Users.Login.Models
{
    public class LoggedInUserDto
    {
        public LoggedInUserDto(int id, string username, string? photoUrl)
        {
            Id = id;
            Username = username;
            PhotoUrl = photoUrl;
        }

        public int Id { get; }

        public string Username { get; }

        public string? PhotoUrl { get; }
    }
}
