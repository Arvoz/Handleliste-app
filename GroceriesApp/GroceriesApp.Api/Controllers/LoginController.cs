using GroceriesApp.Api.Interface;
using GroceriesApp.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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
        public async Task<ActionResult<string>> Login(LoginDto loginDto)
        {
            var appUser = await _userService.ValidateCredentialsAsync(loginDto.Username, loginDto.Password);

            if (appUser is null)
                return Unauthorized("Password or Username is wrong!");

            var token = _token.GenerateToken(appUser);

            return Ok(token);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(LoginDto loginDto)
        {
            var validate = await _userService.CreateNewUser(loginDto);

            if (!validate) return BadRequest("Username allready exist!");

            return Ok("Sucess!");
        }

        [Authorize]
        [HttpGet("test")]
        public async Task<IActionResult> Test()
        {
            var userId = User.FindFirst(ClaimTypes.Name)?.Value;
            var user = await _userService.GetUserByNameAsync(userId);
            return Ok(user);
        }
    }
}