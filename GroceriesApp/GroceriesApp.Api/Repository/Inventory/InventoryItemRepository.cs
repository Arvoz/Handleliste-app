using GroceriesApp.Shared;
using Microsoft.EntityFrameworkCore;

namespace GroceriesApp.Api
{
    public class InventoryItemRepository : Repository<InventoryItem>, IInventoryItemRepository
    {
        public InventoryItemRepository(GroceriesAppDb db) : base(db)
        {
            
        }

        public async Task<bool> CheckIfInventoryAndIngredientIdExistAsync(int inventoryId, int ingredientId)
        {
            return await CheckIfItemExistAsync(ingredientId) && await CheckIfInventoryExistAsync(inventoryId);
        }

        private async Task<bool> CheckIfInventoryExistAsync(int inventoryId)
        {
            var exist = await _db.Inventories.AnyAsync(i => i.Id == inventoryId);

            return exist;
        }

        private async Task<bool> CheckIfItemExistAsync(int itemId)
        {
            var exist = await _db.Ingredients.AnyAsync(i => i.Id == itemId);

            return exist;
        }
    }
}
