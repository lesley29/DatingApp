using System.Collections.Generic;
using Domain.Aggregates.User.ValueObjects;
using Domain.Common;
using NodaTime;

namespace Domain.Aggregates.User.Entities
{
    public class User : IAggregateRoot
    {
        private readonly List<Photo> _photos;

        private User()
        {
            _photos = new List<Photo>();
        }

        protected User(int id, string name, LocalDate dateOfBirth, Gender gender, string knownAs,
            string about, string city, string country, Instant created, Instant lastActive) : this()
        {
            Id = id;
            Name = name;
            DateOfBirth = dateOfBirth;
            Gender = gender;
            KnownAs = knownAs;
            About = about;
            City = city;
            Country = country;
            Created = created;
            LastActive = lastActive;
        }

        public User(string name, Password password, Gender gender, Instant created, Instant lastActive) : this()
        {
            Name = name;
            Password = password;
            Gender = gender;
            Created = created;
            LastActive = lastActive;
        }

        public int Id { get; private set; }

        public string Name { get; private set; }

        public LocalDate? DateOfBirth { get; private set; }

        public Gender Gender { get; private set; }

        public string? KnownAs { get; private set; }

        public string? About { get; private set; }

        public string? City { get; private set; }

        public string? Country { get; private set; }

        public IReadOnlyCollection<Photo> Photos => _photos;

        public Instant Created { get; private set; }

        public Instant LastActive { get; private set; }

        public Password Password { get; private set; } = null!;
    }
}
