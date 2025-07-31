using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceriesApp.Shared
{
    public class Ingredient
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public AppUser? User { get; set; }
        public string? Name { get; set; }
        public IngredientCategory Category { get; set; }
        public IngredientUnitType UnitType { get; set; }
        public decimal DefaultAmount { get; set; }
        public ICollection<IngredientPrice>? IngredientPrices { get; set; }
        public ICollection<InventoryItem>? InventoryItems { get; set; }
        public ICollection<RecipeItem>? RecipeItems { get; set; }
        public ICollection<ShoppingListItem>? ShoppingListItems { get; set; }
    }
}
