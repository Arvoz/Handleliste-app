
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

        public async Task<bool> AddIngredientToInventoryAsync(CreateInventoryItemDto dto, int userId)
        {
            var exist = await _inventoryItemRepository.CheckIfInventoryAndIngredientExistAsync(dto.InventoryId, dto.IngredientId, userId);

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

        public async Task<GetAllInventoriesDto> GetAllInventoriesFromUserAsync(int userId)
        {
            var inventories = await _inventoryRepo.GetAllInventoryAsync(userId);

            if (inventories == null || inventories.Count == 0)
            {
                return null!;
            }

            return ConvertToGetAllInventoriesDto(inventories);
        }

        private GetAllInventoriesDto ConvertToGetAllInventoriesDto(List<Inventory> ingredients)
        {
            return new GetAllInventoriesDto
            {
                Inventories = ingredients.Select(i => new GetInventoryDto
                {
                    Name = i.Name,
                    Ingrediens = i.InventoryItems?.Select(x => new GetInventoryItemDto
                    {
                        Id = x.Id,
                        IngredientId = x.IngredientId,
                        IngredientName = x.Ingredient.Name,
                        InventoryId = x.InventoryId,
                        InventoryName = x.Inventory.Name,
                        Amount = x.Amount,
                        ExpiredDate = x.ExpiredDate
                    }).ToList()
                }).ToList()
            };
        }
    }
}
