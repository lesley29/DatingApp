using System.Collections.Generic;
using System.Linq;
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
            string briefDescription, string? lookingFor, string city, string country, Instant created,
            Instant lastActive, string? interests) : this()
        {
            Id = id;
            Name = name;
            DateOfBirth = dateOfBirth;
            Gender = gender;
            KnownAs = knownAs;
            BriefDescription = briefDescription;
            LookingFor = lookingFor;
            Interests = interests;
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

        public string? BriefDescription { get; private set; }

        public string? LookingFor { get; private set; }

        public string? Interests { get; private set; }

        public string? City { get; private set; }

        public string? Country { get; private set; }

        public IReadOnlyCollection<Photo> Photos => _photos;

        public Instant Created { get; private set; }

        public Instant LastActive { get; private set; }

        public Password Password { get; private set; } = null!;

        public void UpdateInfo(string? briefDescription, string? lookingFor, string? interests, string? city, string? country)
        {
            BriefDescription = briefDescription;
            LookingFor = lookingFor;
            Interests = interests;
            City = city;
            Country = country;
        }

        public void AddPhoto(Photo photo)
        {
            _photos.Add(photo);

            if (_photos.Count == 0)
            {
                photo.MakeMain();
            }
        }

        public void SetPhotoAsMain(string photoName)
        {
            var photo = _photos.FirstOrDefault(p => p.Name == photoName);

            if (photo == null)
            {
                throw new DomainException("Unknown photo");
            }

            photo.MakeMain();
        }
    }
}
