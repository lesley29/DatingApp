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

        protected User(int id, string email, LocalDate dateOfBirth, Gender gender, string name,
            string briefDescription, string? lookingFor, string city, string country, Instant created,
            Instant lastActive, string? interests)
        {
            Id = id;
            Email = email;
            DateOfBirth = dateOfBirth;
            Gender = gender;
            Name = name;
            BriefDescription = briefDescription;
            LookingFor = lookingFor;
            Interests = interests;
            City = city;
            Country = country;
            Created = created;
            LastActive = lastActive;

            _photos = new List<Photo>();
        }

        public User(string email, string name, Password password, LocalDate dateOfBirth, Gender gender, Instant now)
        {
            Email = email;
            Name = name;
            Password = password;
            DateOfBirth = dateOfBirth;
            Gender = gender;
            Created = now;
            LastActive = now;

            _photos = new List<Photo>();
        }

        public int Id { get; private set; }

        public string Email { get; private set; }

        public LocalDate DateOfBirth { get; private set; }

        public Gender Gender { get; private set; }

        public string Name { get; private set; }

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

            _photos.FirstOrDefault(p => p.IsMain)?.MakeOrdinary();

            photo.MakeMain();
        }

        public Photo? GetMainPhoto()
        {
            return _photos.SingleOrDefault(p => p.IsMain);
        }

        public void DeletePhoto(string photoName)
        {
            var photo = _photos.SingleOrDefault(p => p.Name == photoName);

            if (photo == null)
            {
                throw new DomainException("Unknown photo");
            }

            if (photo.IsMain)
            {
                throw new DomainException("It's impossible to delete main photo");
            }

            _photos.Remove(photo);
        }
    }
}
