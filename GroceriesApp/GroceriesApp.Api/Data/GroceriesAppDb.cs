using GroceriesApp.Shared;
using Microsoft.EntityFrameworkCore;

namespace GroceriesApp.Api
{
    public class GroceriesAppDb : DbContext
    {
        public GroceriesAppDb(DbContextOptions<GroceriesAppDb> options) : base(options) { }

        public DbSet<AppUser> Users { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Inventory> Inventory { get; set; }
        public DbSet<IngredientPrice> Prices { get; set; }
        public DbSet<InventoryLog> InventoryLog { get; set; }
    }
}
