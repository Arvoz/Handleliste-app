using GroceriesApp.Shared;

namespace GroceriesApp.Api
{
    public interface IIngredientService
    {
        Task AddIngredientAsync(GlobalIngredientDto dto, int userId, bool isAdmin);
        Task<IngredientsDto> GetIngredientsAsync(int userId);
    }
}
