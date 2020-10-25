using System.Linq;
using System.Threading.Tasks;
using Application.Common;
using Application.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Application.Users.Login
{
    public interface IUserLoginService
    {
        Task<bool> Login(UserLoginRequest request);
    }

    internal class UserLoginService : IUserLoginService
    {
        private readonly IDatingAppDbContext _dbContext;
        private readonly IPasswordHashService _passwordHashService;

        public UserLoginService(IDatingAppDbContext dbContext,
            IPasswordHashService passwordHashService)
        {
            _dbContext = dbContext;
            _passwordHashService = passwordHashService;
        }

        public async Task<bool> Login(UserLoginRequest request)
        {
            var user = await _dbContext.Users.SingleOrDefaultAsync(u => u.Name == request.UserName);

            if (user == null)
            {
                throw new ObjectNotFoundException("No such user");
            }

            var computedHash = _passwordHashService.Hash(request.Password, user.PasswordSalt);

            return !computedHash
                .Where((computedHashByte, i) => computedHashByte != user.PasswordHash[i])
                .Any();
        }
    }
}
