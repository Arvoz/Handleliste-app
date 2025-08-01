using GroceriesApp.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace GroceriesApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientController : ControllerBase
    {
        private readonly IIngredientService _ingredientService;

        public IngredientController(IIngredientService ingredientService)
        {
            _ingredientService = ingredientService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> AddIngrediant(GlobalIngredientDto dto)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
            var isAdmin = User.IsInRole("Admin");
            await _ingredientService.AddIngredientAsync(dto, userId, isAdmin);

            return Ok();
        }

        [HttpGet("get")]
        public async Task<IActionResult> GetIngredients()
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

            var ingredients = await _ingredientService.GetIngredientsAsync(userId);

            return Ok(ingredients);
        }
    }
}
