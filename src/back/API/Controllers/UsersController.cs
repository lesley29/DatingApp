using System.Threading.Tasks;
using API.Auth;
using Application.Users.Login;
using Application.Users.Login.Models;
using Application.Users.Registration;
using Application.Users.Registration.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly IUserRegistrationService _userRegistrationService;
        private readonly IUserLoginService _userLoginService;

        public UsersController(IUserRegistrationService userRegistrationService,
            IUserLoginService userLoginService)
        {
            _userRegistrationService = userRegistrationService;
            _userLoginService = userLoginService;
        }

        [HttpPost("registration")]
        public async Task<RegisteredUserDto> Register(UserRegistrationRequest request)
        {
            var response = await _userRegistrationService.Register(request);

            Response.Cookies.SetToken(response.AccessToken);

            return response.User;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginRequest userLoginRequest)
        {
            var response = await _userLoginService.Login(userLoginRequest);

            if (response == null)
            {
                return Unauthorized();
            }

            Response.Cookies.SetToken(response.AccessToken);

            return Ok(response.LoggedInUser);
        }

        [HttpPost("logout")]
        public IActionResult Logout()
        {
            Response.Cookies.RemoveToken();

            return NoContent();
        }

        [Authorize]
        [HttpGet("secret")]
        public string SuperSecret()
        {
            return "Congrats! You've reached the point";
        }
    }
}
