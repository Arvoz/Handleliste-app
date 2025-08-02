using GroceriesApp.Shared;

namespace GroceriesApp.Api
{
    public class UserInventoryRepository : Repository<UserInventory>, IUserInventoryRepository
    {
        public UserInventoryRepository(GroceriesAppDb db) : base(db)
        {
            
        }
    }
}
