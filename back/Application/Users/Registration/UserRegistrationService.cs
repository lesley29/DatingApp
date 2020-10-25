using System.Threading.Tasks;
using Application.Common;
using Application.Persistence;
using Domain.Entities;

namespace Application.Users.Registration
{
    internal class UserRegistrationService : IUserRegistrationService
    {
        private readonly IDatingAppDbContext _dbContext;
        private readonly IPasswordHashService _passwordHashService;

        public UserRegistrationService(IDatingAppDbContext dbContext,
            IPasswordHashService passwordHashService)
        {
            _dbContext = dbContext;
            _passwordHashService = passwordHashService;
        }

        public Task Register(UserRegistrationRequest request)
        {
            var (passwordHash, passwordSalt) = _passwordHashService.Generate(request.Password);

            var user = new User(request.UserName, passwordHash, passwordSalt);

            _dbContext.Users.Add(user);

            return _dbContext.SaveChangesAsync();
        }
    }
}
