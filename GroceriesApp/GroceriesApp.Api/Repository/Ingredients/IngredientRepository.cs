using GroceriesApp.Api.Migrations;
using GroceriesApp.Shared;
using Microsoft.EntityFrameworkCore;

namespace GroceriesApp.Api
{
    public class IngredientRepository : Repository<Ingredient>, IIngredientRepository
    {
        public IngredientRepository(GroceriesAppDb db) : base(db)
        {

        }

        public async Task<List<Ingredient>> GetIngredientsAsync(int userId)
        {
            return await _db.Ingredients
                .Include(i => i.IngredientPrices)
                .Where(u => u.UserId == null || u.UserId == userId)
                .ToListAsync();
        }
    }
}
