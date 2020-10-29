namespace Application.Users
{
    public class UserDto
    {
        public UserDto(string userName, string token)
        {
            UserName = userName;
            Token = token;
        }

        public string UserName { get; }

        public string Token { get; }
    }
}
