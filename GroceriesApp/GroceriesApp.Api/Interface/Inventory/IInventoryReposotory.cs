using GroceriesApp.Shared;

namespace GroceriesApp.Api
{
    public interface IInventoryReposotory : IRepository<Inventory>
    {
        Task<Inventory?> GetByNameAsync(string name);
        Task<bool> CheckUserInventory(AppUser user, string name);
    }
}
