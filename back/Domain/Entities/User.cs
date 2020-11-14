using Domain.ValueObjects;

namespace Domain.Entities
{
    public class User
    {
        protected User(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public User(string name, Password password)
        {
            Name = name;
            Password = password;
        }

        public int Id { get; private set; }

        public string Name { get; private set; }

        public Password Password { get; private set; } = null!;
    }
}
