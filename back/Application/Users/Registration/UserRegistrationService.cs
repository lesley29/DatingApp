using System.Threading.Tasks;
using Application.Common;
using Application.Persistence;
using Application.Users.Login.Models;
using Application.Users.Registration.Models;
using Domain.Entities;

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

            var user = new User(request.UserName, passwordHash, passwordSalt);

            _dbContext.Users.Add(user);

            await _dbContext.SaveChangesAsync();

            return new UserRegistrationResponse(new RegisteredUserDto(user.Name), _tokenService.Generate(user));
        }
    }
}
