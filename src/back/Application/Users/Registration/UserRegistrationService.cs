using System.Threading.Tasks;
using Application.Common.Cryptography;
using Application.Common.Identity;
using Application.Persistence;
using Application.Users.Registration.Models;
using Domain;
using Domain.Aggregates.User.Entities;
using Domain.Aggregates.User.ValueObjects;
using NodaTime;

namespace Application.Users.Registration
{
    internal class UserRegistrationService : IUserRegistrationService
    {
        private readonly IDatingAppDbContext _dbContext;
        private readonly ITokenService _tokenService;
        private readonly IPasswordHashService _passwordHashService;
        private readonly IClock _clock;

        public UserRegistrationService(IDatingAppDbContext dbContext,
            ITokenService tokenService,
            IPasswordHashService passwordHashService,
            IClock clock)
        {
            _dbContext = dbContext;
            _tokenService = tokenService;
            _passwordHashService = passwordHashService;
            _clock = clock;
        }

        public async Task<UserRegistrationResponse> Register(UserRegistrationRequest request)
        {
            var (passwordHash, passwordSalt) = _passwordHashService.Generate(request.Password);

            var password = new Password(passwordHash, passwordSalt);
            var now = _clock.GetCurrentInstant();
            var user = new User(request.UserName, password, Gender.Unknown, now, now);

            _dbContext.Users.Add(user);

            await _dbContext.SaveChangesAsync();

            var registeredUserDto = new RegisteredUserDto(user.Id, user.Name);

            return new UserRegistrationResponse(registeredUserDto, _tokenService.Generate(user));
        }
    }
}
