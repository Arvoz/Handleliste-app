
using GroceriesApp.Shared;

namespace GroceriesApp.Api
{
    public class InventoryService : IInventoryService
    {
        private readonly IInventoryReposotory _inventoryRepo;
        private readonly IUserInventoryRepository _userInventoryRepo;

        public InventoryService(IInventoryReposotory inventoryRepo,
                                IUserInventoryRepository userInventoryRepo)
        {
            _inventoryRepo = inventoryRepo;
            _userInventoryRepo = userInventoryRepo;
        }

        public async Task<bool> AddInventoryAsync(string name, AppUser user)
        {
            var existing = await _inventoryRepo.CheckUserInventory(user, name);

            if (!existing)
            {
                return false;
            }

            var inventory = new Inventory { Name = name };
            await _inventoryRepo.AddAsync(inventory);

            var userInventory = new UserInventory
            {
                UserId = user.Id,
                InventoryId = inventory.Id
            };

            await _userInventoryRepo.AddAsync(userInventory);

            return true;

        }

        public Task<Inventory> GetInventoryByNameAsync(string name, int userId)
        {
            throw new NotImplementedException();
        }
    }
}
