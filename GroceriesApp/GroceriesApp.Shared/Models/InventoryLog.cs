using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceriesApp.Shared
{
    public class InventoryLog
    {
        public int Id { get; set; }
        public int InventoryId { get; set; }
        public Inventory Inventory { get; set; }
        public int UserId { get; set; }
        public AppUser User { get; set; }
        public LogState State { get; set; }
        public IngredientUnitType Unit { get; set; }
        public decimal Amount { get; set; }
        public decimal? Price { get; set; }
        public PriceCurrency Currency { get; set; }
        public DateTime TimeAdded { get; set; }
        public string? Description { get; set; }
    }
}
