using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GroceriesApp.Api;
using GroceriesApp.Shared;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace GroceriesApp.Tests.Services;

public class IngredientServiceTests
{
    [Fact]
    public async Task AddIngredientAsync_WhenUserIsNotAdmin_ShouldSetUserId()
    {
        // Arrange
        var dto = new GlobalIngredientDto
        {
            Name = "Melk",
            Category = IngredientCategory.Dairy,
            UnitType = IngredientUnitType.Liters,
            DefaultAmount = 1,
            Prices = new List<IngredientPriceDto>
            {
                new() { Price = 25, Currency = PriceCurrency.Nok},
                new() { Price = 15, Currency = PriceCurrency.Sek}
            }
        };

        var ingredientRepo = new Mock<IIngredientRepository>();
        var priceRepo = new Mock<IIngredientPriceRepository>();

        var service = new IngredientService(ingredientRepo.Object, priceRepo.Object);
        // Act
        await service.AddIngredientAsync(dto, userId: 5, isAdmin: false);

        // Assert
        ingredientRepo.Verify(repo => repo.AddAsync(It.Is<Ingredient>(
            i => i.UserId == 5 && i.Name == "Melk")), Times.Once);

        ingredientRepo.Verify(repo => repo.AddAsync(It.Is<Ingredient>(
            ip => ip.IngredientPrices!.Any(p => p.Price == 25 && p.Currency == PriceCurrency.Nok))), Times.Once);
    }

    [Fact]
    public async Task AddIngredientAsync_WhenUserIsAdmin_ShouldNotSetUserId()
    {
        // Arrange
        var dto = new GlobalIngredientDto
        {
            Name = "Melk",
            Category = IngredientCategory.Dairy,
            UnitType = IngredientUnitType.Liters,
            DefaultAmount = 1,
            Prices = new List<IngredientPriceDto>
            {
                new() { Price = 25, Currency = PriceCurrency.Nok },
                new() { Price = 15, Currency = PriceCurrency.Sek },
            }
        };

        var ingredientRepo = new Mock<IIngredientRepository>();
        var priceRepo = new Mock<IIngredientPriceRepository>();

        var service = new IngredientService(ingredientRepo.Object, priceRepo.Object);
        // Act
        await service.AddIngredientAsync(dto, userId: 5, isAdmin: true);

        // Assert
        ingredientRepo.Verify(repo => repo.AddAsync(It.Is<Ingredient>(
            i => i.UserId == null && i.Name == "Melk")), Times.Once);

    }
    
}
