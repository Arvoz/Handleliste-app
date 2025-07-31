using GroceriesApp.Shared;

namespace GroceriesApp.Api
{
    public interface IIngredientService
    {
        Task AddIngredientAsync(IngredientEntityDto dto, int userId);
    }
}
