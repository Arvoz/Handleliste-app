using GroceriesApp.Shared;
using Microsoft.EntityFrameworkCore;

namespace GroceriesApp.Api
{
    public class GroceriesAppDb : DbContext
    {
        public GroceriesAppDb(DbContextOptions<GroceriesAppDb> options) : base(options) { }

        public DbSet<AppUser> Users { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<InventoryItem> InventoryItems { get; set; }
        public DbSet<IngredientPrice> IngredientPrices { get; set; }
        public DbSet<InventoryLog> InventoryLogs { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<RecipeItem> RecipeItems { get; set; }
        public DbSet<ShoppingList> ShoppingLists { get; set; }
        public DbSet<ShoppingListItem> ShoppingListItems { get; set; }
        public DbSet<UserInventory> UserInventory { get; set; }
    }
}
