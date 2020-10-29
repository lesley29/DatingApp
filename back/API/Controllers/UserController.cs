using System.Threading.Tasks;
using Application.Users;
using Application.Users.Login;
using Application.Users.Registration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IUserRegistrationService _userRegistrationService;
        private readonly IUserLoginService _userLoginService;

        public UserController(IUserRegistrationService userRegistrationService,
            IUserLoginService userLoginService)
        {
            _userRegistrationService = userRegistrationService;
            _userLoginService = userLoginService;
        }

        [HttpPost("registration")]
        public Task<UserDto> Register(UserRegistrationRequest request)
        {
            return _userRegistrationService.Register(request);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginRequest userLoginRequest)
        {
            var loggedInUser = await _userLoginService.Login(userLoginRequest);

            if (loggedInUser == null)
            {
                return Unauthorized();
            }

            return Ok(loggedInUser);
        }

        [Authorize]
        [HttpGet("secret")]
        public string SuperSecret()
        {
            return "Congrats! You've reached the point";
        }
    }
}
