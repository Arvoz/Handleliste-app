using GroceriesApp.Api;
using GroceriesApp.Shared;
using Microsoft.EntityFrameworkCore;

namespace GroceriesApp.Tests.Repositories;

public class IngredientRepositoryTests
{
    [Fact]
    public async Task GetIngredientsAsync_UserWithAnotherUserId_ShouldNotReturnUserInventory()
    {
        var options = new DbContextOptionsBuilder<GroceriesAppDb>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        await using var context = new GroceriesAppDb(options);

        // Arrange
        var userId = 123;
        var testUserId = 69;

        var globalIngredient = new Ingredient
        {
            Name = "Melk",
            UserId = null,
            IngredientPrices = new List<IngredientPrice>
            {
                new() { Price = 10, Currency = PriceCurrency.Nok },
                new() { Price = 5, Currency = PriceCurrency.Sek },
            }
        };


        var userIngredient = new Ingredient
        {
            Name = "Brød",
            UserId = userId,
            IngredientPrices = new List<IngredientPrice>
            {
                new() { Price = 10, Currency = PriceCurrency.Nok },
                new() { Price = 5, Currency = PriceCurrency.Sek },
            }

        };

        context.Ingredients.AddRange(globalIngredient, userIngredient);
        await context.SaveChangesAsync();

        var repo = new IngredientRepository(context);

        // Act
        var result = await repo.GetIngredientsAsync(testUserId);

        // Assert
        Assert.NotNull(result);
        Assert.DoesNotContain(result, i => i.Name == "Brød");
        Assert.Contains(result, i => i.Name == "Melk");
    }

    [Fact]
    public async Task GetIngredientsAsync_WithValidUserId_ShouldReturnUserInventoryAndGlobal()
    {
        var options = new DbContextOptionsBuilder<GroceriesAppDb>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        await using var context = new GroceriesAppDb(options);

        // Arrange
        var userId = 123;

        var globalIngredient = new Ingredient
        {
            Name = "Melk",
            UserId = null,
            IngredientPrices = new List<IngredientPrice>
            {
                new() { Price = 10, Currency = PriceCurrency.Nok },
                new() { Price = 5, Currency = PriceCurrency.Sek },
            }
        };

        var userIngredient = new Ingredient
        {
            Name = "Brød",
            UserId = userId,
            IngredientPrices = new List<IngredientPrice>
            {
                new() { Price = 10, Currency = PriceCurrency.Nok },
                new() { Price = 5, Currency = PriceCurrency.Sek },
            }

        };

        context.Ingredients.AddRange(globalIngredient, userIngredient);
        await context.SaveChangesAsync();

        var repo = new IngredientRepository(context);

        // Act
        var result = await repo.GetIngredientsAsync(userId);

        // Assert
        Assert.NotNull(result);
        Assert.Contains(result, i => i.Name == "Melk");
        Assert.Contains(result, i => i.Name == "Brød");
    }

}
