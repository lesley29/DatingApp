using System.Linq;
using System.Threading.Tasks;
using Application.Common;
using Application.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Application.Users.Login
{
    internal class UserLoginService : IUserLoginService
    {
        private readonly IDatingAppDbContext _dbContext;
        private readonly ITokenService _tokenService;
        private readonly IPasswordHashService _passwordHashService;

        public UserLoginService(IDatingAppDbContext dbContext,
            ITokenService tokenService,
            IPasswordHashService passwordHashService)
        {
            _dbContext = dbContext;
            _tokenService = tokenService;
            _passwordHashService = passwordHashService;
        }

        public async Task<UserDto?> Login(UserLoginRequest request)
        {
            var user = await _dbContext.Users.SingleOrDefaultAsync(u => u.Name == request.UserName);

            if (user == null)
            {
                throw new ObjectNotFoundException("No such user");
            }

            var computedHash = _passwordHashService.Hash(request.Password, user.PasswordSalt);

            var isPasswordCorrect = !computedHash
                .Where((computedHashByte, i) => computedHashByte != user.PasswordHash[i])
                .Any();

            return isPasswordCorrect ? new UserDto(user.Name, _tokenService.Generate(user)) : null;
        }
    }
}
