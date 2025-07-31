using GroceriesApp.Shared;

namespace GroceriesApp.Api.Repository
{
    public class IngredientPriceRepository : Repository<IngredientPrice>, IIngredientPriceRepository
    {
        public IngredientPriceRepository(GroceriesAppDb db) : base(db)
        {
            
        }
    }
}
