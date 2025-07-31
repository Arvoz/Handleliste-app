using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace GroceriesApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly IInventoryService _inventory;
        private readonly IUserService _userService;

        public InventoryController(IInventoryService inventory, IUserService userService)
        {
            _inventory = inventory;
            _userService = userService;
        }

        [Authorize]
        [HttpPost("addInventory")]
        public async Task<IActionResult> AddInventory(string name)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
            var user = await _userService.GetByIdAsync(userId);

            var check = await _inventory.AddInventoryAsync(name, user);

            if (!check)
            {
                return BadRequest($"{name} is aleady named!");
            }

            return Ok($"{userId} has added {name} to it's inventory!");
        }
    }
}
