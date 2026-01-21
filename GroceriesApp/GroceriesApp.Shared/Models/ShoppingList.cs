using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceriesApp.Shared
{
    public class ShoppingList
    {
        public int Id { get; set; }
        public string? Name { get; set; } 
        public int InventoryId { get; set; }
        public Inventory? Inventory { get; set; } 
        public DateTime Created { get; set; }
        public ICollection<ShoppingListItem> ShoppingListItems { get; set; } = new List<ShoppingListItem>();
    }
}
