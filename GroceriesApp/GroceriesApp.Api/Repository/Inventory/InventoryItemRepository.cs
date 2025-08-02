using GroceriesApp.Shared;
using Microsoft.EntityFrameworkCore;

namespace GroceriesApp.Api
{
    public class InventoryItemRepository : Repository<InventoryItem>, IInventoryItemRepository
    {
        public InventoryItemRepository(GroceriesAppDb db) : base(db)
        {
            
        }

        public async Task<bool> CheckIfInventoryAndIngredientExistAsync(int inventoryId, int ingredientId, int userId)
        {
            return await CheckIfItemExistAsync(ingredientId, userId) && await CheckIfInventoryExistAsync(inventoryId, userId);
        }

        private async Task<bool> CheckIfInventoryExistAsync(int inventoryId, int userId)
        {
            return await _db.UserInventory
                .AnyAsync(ui => ui.UserId == userId && ui.InventoryId == inventoryId);
        }

        private async Task<bool> CheckIfItemExistAsync(int itemId, int userId)
        {
            return await _db.Ingredients
                .AnyAsync(i => i.Id == itemId && (i.UserId == null || i.UserId == userId));
        }
    }
}
