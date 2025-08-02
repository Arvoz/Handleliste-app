using GroceriesApp.Shared;

namespace GroceriesApp.Api
{
    public interface IInventoryService
    {
        Task<bool> AddInventoryAsync(string name, int userId);
        Task<bool> AddIngredientToInventoryAsync(CreateInventoryItemDto dto);
    }
}
