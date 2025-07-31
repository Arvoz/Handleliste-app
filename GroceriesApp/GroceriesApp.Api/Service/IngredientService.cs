using GroceriesApp.Api;
using GroceriesApp.Shared;

namespace GroceriesApp.Api.Service
{
    public class IngredientService : IIngredientService
    {
        private readonly IIngredientRepository _ingredientRepo;
        private readonly IIngredientPriceRepository _ingredientPriceRepo;

        public IngredientService(IIngredientRepository ingredient, IIngredientPriceRepository ingredientPriceRepo)
        {
            _ingredientRepo = ingredient;
            _ingredientPriceRepo = ingredientPriceRepo;
        }

        public async Task AddIngredientAsync(IngredientEntityDto  dto, int userId)
        {
            var ingredient = dto.ConvertFromIngredientDto(dto.Ingredient);
            var ingredientPrice = dto.ConvertFromIngredientPriceDto(dto.IngredientPrice);

            ingredient.UserId = userId;

            await _ingredientRepo.AddAsync(ingredient);

            ingredientPrice.IngredientId = ingredient.Id;

            await _ingredientPriceRepo.AddAsync(ingredientPrice);
        }
    }
}
