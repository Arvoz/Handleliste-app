using GroceriesApp.Shared;

namespace GroceriesApp.Api
{
    public interface IInventoryItemRepository : IRepository<InventoryItem>
    {
        Task<bool> CheckIfInventoryAndIngredientExistAsync(int inventoryId, int ingredientId, int userId);
    }
}
