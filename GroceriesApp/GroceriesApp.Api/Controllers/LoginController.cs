using GroceriesApp.Api.Interface;
using GroceriesApp.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GroceriesApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ITokenService _token;

        public LoginController(IUserService userService, ITokenService token)
        {
            _userService = userService;
            _token = token;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var user = await _userService.ValidateCredentialsAsync(loginDto.Username, loginDto.Password);

            if (!user)
                return Unauthorized();

            var appUser = await _userService.GetUserByNameAsync(loginDto.Username);

            var token = _token.GenerateToken(appUser);

            return Ok(new { token });
        }
    }
}