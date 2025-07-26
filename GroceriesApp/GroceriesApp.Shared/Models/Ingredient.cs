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
        public string Name { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public IngredientUnitType UnitType { get; set; }
        public decimal DefaultAmount { get; set; }
        public ICollection<IngredientPrice> IngredientPrices { get; set; } = new List<IngredientPrice>();
        public ICollection<InventoryItem> InventoryItems { get; set; } = new List<InventoryItem>();
        public ICollection<RecipeItem> RecipeItems { get; set; } = new List<RecipeItem>();
        public ICollection<ShoppingListItem> ShoppingListItems { get; set; } = new List<ShoppingListItem>();
    }
}
