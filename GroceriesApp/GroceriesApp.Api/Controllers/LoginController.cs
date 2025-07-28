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
                return Unauthorized("hehehe");

            var appUser = await _userService.GetUserByNameAsync(loginDto.Username);

            var token = _token.GenerateToken(appUser);

            return Ok(token);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(LoginDto loginDto)
        {
            if (await _userService.GetUserByNameAsync(loginDto.Username) is null)
            {
                var user = new AppUser
                {
                    Username = loginDto.Username,
                    Password = loginDto.Password,
                    Role = UserRole.User,
                    Created = DateTime.UtcNow
                };

                await _userService.AddAsync(user);
                return Ok();
            }

            return BadRequest();

            
        }
    }
}