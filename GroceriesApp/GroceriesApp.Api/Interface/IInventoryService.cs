using GroceriesApp.Shared;

namespace GroceriesApp.Api
{
    public interface IInventoryService
    {
        Task<bool> AddInventoryAsync(string name, AppUser user);
    }
}
