using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Identity;
using Application.Persistence;
using Application.Users.Login.Models;
using Microsoft.EntityFrameworkCore;

namespace Application.Users.Login
{
    internal class UserLoginService : IUserLoginService
    {
        private readonly IDatingAppDbContext _dbContext;
        private readonly ITokenService _tokenService;
        private readonly IPasswordValidator _passwordValidator;

        public UserLoginService(IDatingAppDbContext dbContext,
            ITokenService tokenService,
            IPasswordValidator passwordValidator)
        {
            _dbContext = dbContext;
            _tokenService = tokenService;
            _passwordValidator = passwordValidator;
        }

        public async Task<UserLoginResponse?> Login(UserLoginRequest request)
        {
            var user = await _dbContext.Users.SingleOrDefaultAsync(u => u.Name == request.Username);

            if (user == null)
            {
                throw new ResourceNotFoundException();
            }

            var isPasswordValid = _passwordValidator.Validate(request.Password, user.Password);

            return isPasswordValid
                ? new UserLoginResponse(new LoggedInUserDto(user.Name), _tokenService.Generate(user))
                : null;
        }
    }
}
