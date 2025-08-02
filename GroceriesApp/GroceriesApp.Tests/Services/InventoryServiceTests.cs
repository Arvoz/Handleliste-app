using GroceriesApp.Api;
using GroceriesApp.Shared;
using Moq;
namespace GroceriesApp.Tests.Services
{
    public class InventoryServiceTests
    {
        private Mock<IInventoryReposotory> _inventoryRepoMock;
        private Mock<IUserInventoryRepository> _userInventoryRepoMock;
        private Mock<IInventoryItemRepository> _inventoryItemRepoMock;
        private InventoryService _service;

        public InventoryServiceTests()
        {
            _inventoryRepoMock = new Mock<IInventoryReposotory>();
            _userInventoryRepoMock = new Mock<IUserInventoryRepository>();
            _inventoryItemRepoMock = new Mock<IInventoryItemRepository>();
            _service = new InventoryService(_inventoryRepoMock.Object, _userInventoryRepoMock.Object, _inventoryItemRepoMock.Object);

        }

        [Fact]
        public async Task AddInventoryAsync_WithUserIdAndInventoryName_ShouldCreateAndSaveInventory()
        {
            var inventoryName = "test";
            var userId = 1;

            _inventoryRepoMock
                .Setup(repo => repo.CheckUserInventory(userId, inventoryName))
                .ReturnsAsync(false);

            // Act
            await _service.AddInventoryAsync(inventoryName, userId); 

            // Assert
            _inventoryRepoMock.Verify(repo => repo.AddAsync(It.Is<Inventory>(
                i => i.Name == inventoryName &&
                     i.UserInventories != null &&
                     i.UserInventories.Count == 1 &&
                     i.UserInventories.First().UserId == userId)), Times.Once);
        }

        [Fact]
        public async Task AddIngredientToInventoryAsync_WithDtoAndUserId_ShouldCreateAndSaveCorrectly()
        {
            // Arrange
            var userId = 13;
            var dto = CreateDto();

            _inventoryItemRepoMock
                .Setup(repo => repo.CheckIfInventoryAndIngredientExistAsync(dto.InventoryId, dto.IngredientId, userId))
                .ReturnsAsync(true);

            // Act
            await _service.AddIngredientToInventoryAsync(dto, userId);

            // Assert
            _inventoryItemRepoMock.Verify(repo => repo.AddAsync(It.Is<InventoryItem>(
                i => i.InventoryId == dto.InventoryId &&
                     i.Amount == dto.Amount &&
                     i.IngredientId == 1)), Times.Once);
        }

        [Fact]
        public async Task GetAllInventoriesFromUserAsync_WhenUserHaveInventory_ShouldReturnInventory()
        {
            // Arrange
            var userId = 69;
            var userInv1 = new UserInventory
            {
                Id = 15,
                UserId = userId,
                User = null,
                InventoryId = 13,
                Inventory = null
            };

            var inventory = new Inventory
            {
                Id = 13,
                Name = "Test",
                UserInventories = new List<UserInventory>
                {
                    userInv1
                },
                InventoryItems = new List<InventoryItem>()
                {
                    new InventoryItem
                    {
                        Id = 19,
                        IngredientId = 1,
                        Ingredient = new Ingredient
                        {
                            Id = 1,
                            Name = "Banan"
                        },
                        InventoryId = 13,
                        Inventory = new Inventory
                        {
                            Id = 13,
                            Name = "Test"
                        },
                        Amount = 1,
                    }
                }
            };

            var inventories = new List<Inventory>()
            {
                inventory
            };


            _inventoryRepoMock
                .Setup(repo => repo.GetAllInventoryAsync(userId))
                .ReturnsAsync(inventories);

            // Act
            var result = await _service.GetAllInventoriesFromUserAsync(userId);

            // Assert
            Assert.NotNull(result);
            Assert.Contains("Test", result.Inventories![0].Name);
            Assert.Contains(19, result.Inventories[0].Ingrediens.Select(i => i.Id));
            Assert.Contains("Banan", result.Inventories[0].Ingrediens.Select(i => i.IngredientName));
            Assert.Contains("Test", result.Inventories[0].Ingrediens.Select(i => i.InventoryName));
        }

        private CreateInventoryItemDto CreateDto()
        {
            return new CreateInventoryItemDto
            {
                IngredientId = 1,
                InventoryId = 12,
                Amount = 2
            };
        }
    }
}
