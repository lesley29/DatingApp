using System.Collections.Generic;
using Application.Common;
using Application.Members.Common;
using Domain;
using NodaTime;

namespace Application.Members.Queries
{
    public class MemberDto
    {
        public MemberDto(int id, string name, LocalDate? dateOfBirth, Gender gender, string? knownAs,
            string? lookingFor, string? briefDescription, string? city,
            string? country, List<PhotoDto> photos, Instant created, Instant lastActive)
        {
            Id = id;
            Name = name;
            DateOfBirth = dateOfBirth;
            Gender = gender;
            KnownAs = knownAs;
            BriefDescription = briefDescription;
            City = city;
            Country = country;
            Photos = photos;
            Created = created;
            LastActive = lastActive;
            LookingFor = lookingFor;
        }

        public int Id { get; private set; }

        public string Name { get; private set; }

        public LocalDate? DateOfBirth { get; private set; }

        public Gender Gender { get; private set; }

        public string? KnownAs { get; private set; }

        public string? BriefDescription { get; private set; }

        public string? LookingFor { get; private set; }

        public string? City { get; private set; }

        public string? Country { get; private set; }

        public List<PhotoDto> Photos { get; set; }

        public Instant Created { get; private set; }

        public Instant LastActive { get; private set; }
    }
}
