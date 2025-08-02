
using GroceriesApp.Shared;

namespace GroceriesApp.Api
{
    public class InventoryService : IInventoryService
    {
        private readonly IInventoryReposotory _inventoryRepo;
        private readonly IUserInventoryRepository _userInventoryRepo;
        private readonly IInventoryItemRepository _inventoryItemRepository;

        public InventoryService(IInventoryReposotory inventoryRepo,
                                IUserInventoryRepository userInventoryRepo,
                                IInventoryItemRepository inventoryItemRepository)
        {
            _inventoryRepo = inventoryRepo;
            _userInventoryRepo = userInventoryRepo;
            _inventoryItemRepository = inventoryItemRepository;
        }

        public async Task<bool> AddInventoryAsync(string name, int userId)
        {
            var existing = await _inventoryRepo.CheckUserInventory(userId, name);

            if (!existing)
            {
                return false;
            }

            var inventory = new Inventory 
            { 
                Name = name,
                UserInventories = new List<UserInventory>
                {
                    new UserInventory
                    {
                        UserId = userId
                    }
                }
            };

            await _inventoryRepo.AddAsync(inventory);

            return true;
            //var userInventory = new UserInventory
            //{
            //    UserId = userId,
            //    InventoryId = inventory.Id
            //};

            // await _userInventoryRepo.AddAsync(userInventory);
        }

        public Task<Inventory> GetInventoryByNameAsync(string name, int userId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> AddIngredientToInventoryAsync(CreateInventoryItemDto dto)
        {
            var exist = await _inventoryItemRepository.CheckIfInventoryAndIngredientIdExistAsync(dto.InventoryId, dto.IngredientId);

            if (!exist)
            {
                return false;
            } 

            if (dto.Amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(dto.Amount), $"{dto.Amount} cannot be zero or lower, it must be greater than zero");
            }

            var inventoryItem = new InventoryItem
            {
                IngredientId = dto.IngredientId,
                InventoryId = dto.InventoryId,
                Amount = dto.Amount,
                Created = DateTime.UtcNow,
                ExpiredDate = dto.ExpiredDate
            };

            await _inventoryItemRepository.AddAsync(inventoryItem);

            return true;

        }
    }
}
