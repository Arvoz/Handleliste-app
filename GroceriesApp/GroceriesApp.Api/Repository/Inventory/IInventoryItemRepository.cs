using GroceriesApp.Shared;

namespace GroceriesApp.Api
{
    public interface IInventoryItemRepository : IRepository<InventoryItem>
    {
        Task<bool> CheckIfInventoryAndIngredientIdExistAsync(int inventoryId, int ingredientId);
    }
}
