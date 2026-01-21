using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceriesApp.Shared
{
    public class InventoryItem
    {
        public int Id { get; set; }
        public int IngredientId { get; set; }
        public Ingredient? Ingredient { get; set; }
        public int InventoryId { get; set; }
        public Inventory? Inventory { get; set; }
        public decimal Amount { get; set; }
        public DateTime Created { get; set; }
        public DateTime? ExpiredDate { get; set; }
        public ICollection<InventoryLog> InventoryLogs { get; set; } = new List<InventoryLog>();
    }
}
