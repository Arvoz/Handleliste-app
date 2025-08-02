using GroceriesApp.Api;
using GroceriesApp.Shared;

namespace GroceriesApp.Api
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

        public async Task AddIngredientAsync(GlobalIngredientDto dto, int userId, bool isAdmin)
        {
            var ingredient = dto.ConvertFromIngredientDto(dto);

            ingredient.UserId = isAdmin ? null : userId;
            await _ingredientRepo.AddAsync(ingredient);
        }

        public async Task<IngredientsDto> GetIngredientsAsync(int userId)
        {
            var ingredients = await _ingredientRepo.GetIngredientsAsync(userId);

            return new IngredientsDto
            {
                Ingredients = ingredients.Select(i => new GlobalIngredientDto
                {
                    Id = i.Id,
                    Name = i.Name,
                    Category = i.Category,
                    Prices = i.IngredientPrices.Select(p => new IngredientPriceDto
                    {
                        Id = p.Id,
                        Price = p.Price,
                        Currency = p.Currency
                    }).ToList()
                }).ToList()
            };
        }
    }
}
