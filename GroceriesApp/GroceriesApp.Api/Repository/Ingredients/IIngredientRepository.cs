using GroceriesApp.Shared;

namespace GroceriesApp.Api
{
    public interface IIngredientRepository : IRepository<Ingredient>
    {
        Task<List<Ingredient>> GetIngredientsAsync(int userId);
    }
}
