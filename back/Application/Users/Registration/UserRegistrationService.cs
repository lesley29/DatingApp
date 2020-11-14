using System.Threading.Tasks;
using Application.Common.Cryptography;
using Application.Common.Identity;
using Application.Persistence;
using Application.Users.Registration.Models;
using Domain.Entities;
using Domain.ValueObjects;

namespace Application.Users.Registration
{
    internal class UserRegistrationService : IUserRegistrationService
    {
        private readonly IDatingAppDbContext _dbContext;
        private readonly ITokenService _tokenService;
        private readonly IPasswordHashService _passwordHashService;

        public UserRegistrationService(IDatingAppDbContext dbContext,
            ITokenService tokenService,
            IPasswordHashService passwordHashService)
        {
            _dbContext = dbContext;
            _tokenService = tokenService;
            _passwordHashService = passwordHashService;
        }

        public async Task<UserRegistrationResponse> Register(UserRegistrationRequest request)
        {
            var (passwordHash, passwordSalt) = _passwordHashService.Generate(request.Password);
            var password = new Password(passwordHash, passwordSalt);
            var user = new User(request.UserName, password);

            _dbContext.Users.Add(user);

            await _dbContext.SaveChangesAsync();

            return new UserRegistrationResponse(new RegisteredUserDto(user.Name), _tokenService.Generate(user));
        }
    }
}
