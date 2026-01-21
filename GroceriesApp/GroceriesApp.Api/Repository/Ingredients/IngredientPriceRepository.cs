using GroceriesApp.Shared;

namespace GroceriesApp.Api
{
    public class IngredientPriceRepository : Repository<IngredientPrice>, IIngredientPriceRepository
    {
        public IngredientPriceRepository(GroceriesAppDb db) : base(db)
        {
            
        }
    }
}
