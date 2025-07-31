using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceriesApp.Shared
{
    public class ShoppingListItem
    {
        public int Id { get; set; }
        public int IngredientId { get; set; }
        public Ingredient? Ingredient { get; set; }
        public int ShoppingListId { get; set; }
        public ShoppingList? ShoppingList { get; set; } 
        public decimal Amount { get; set; }
        public bool ItemChecked { get; set; }
    }
}
