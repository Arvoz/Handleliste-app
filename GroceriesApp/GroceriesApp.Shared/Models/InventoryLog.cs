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
        public int InventoryItemId { get; set; }
        public InventoryItem? InventoryItem { get; set; }
        public int UserId { get; set; }
        public AppUser? User { get; set; }
        public LogState? StateAction { get; set; }
        public IngredientUnitType? Unit { get; set; }
        public decimal Amount { get; set; }
        public decimal? Price { get; set; }
        public PriceCurrency? PriceCurrency { get; set; }
        public DateTime? TimeAdded { get; set; }
        public string? Description { get; set; }
    }
}
