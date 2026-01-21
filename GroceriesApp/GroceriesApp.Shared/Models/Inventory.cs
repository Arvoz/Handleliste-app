using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceriesApp.Shared
{
    public class Inventory
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public ICollection<UserInventory> UserInventories { get; set; } = new List<UserInventory>();
        public ICollection<InventoryItem> InventoryItems { get; set; } = new List<InventoryItem>();
        public ICollection<ShoppingList> ShoppingLists { get; set; } = new List<ShoppingList>();
    }
}
