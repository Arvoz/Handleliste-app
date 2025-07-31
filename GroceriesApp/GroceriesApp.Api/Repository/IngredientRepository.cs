using GroceriesApp.Api.Migrations;
using GroceriesApp.Shared;

namespace GroceriesApp.Api
{
    public class IngredientRepository : Repository<Ingredient>, IIngredientRepository
    {
        public IngredientRepository(GroceriesAppDb db) : base(db)
        {
            
        }
    }
}
