using GroceriesApp.Shared;
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
            var userId = GetUserId();

            var check = await _inventory.AddInventoryAsync(name, userId);

            if (!check)
            {
                return BadRequest($"{name} is aleady named!");
            }

            return Ok($"{userId} has added {name} to it's inventory!");
        }

        [Authorize]
        [HttpPost("ingredient")]
        public async Task<IActionResult> AddIngredientToInventory(CreateInventoryItemDto dto)
        {
            var userId = GetUserId();
            var addIngredient = await _inventory.AddIngredientToInventoryAsync(dto, userId);

            if (!addIngredient)
            {
                return BadRequest($"Could not found {dto.IngredientId} or {dto.InventoryId}");
            }

            return Ok("200");
        }

        [Authorize]
        [HttpGet("Inventory")]
        public async Task<IActionResult> GetInventory()
        {
            var userId = GetUserId();
            var inventories = await _inventory.GetAllInventoriesFromUserAsync(userId);

            if (inventories == null)
            {
                return BadRequest("User have no inventories!");
            }

            return Ok(inventories);
        }

        private int GetUserId()
        {
            return int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
        }

    }
}
