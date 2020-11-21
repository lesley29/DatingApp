namespace Application.Users
{
    public interface IAuthenticatedUser
    {
        public int Id { get; }

        public string Username { get; }
    }
}
