using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceriesApp.Shared
{
    public class GetInventoryItemDto
    {
        public int Id { get; set; }
        public int IngredientId { get; set; }
        public string IngredientName { get; set; } = string.Empty;
        public int InventoryId { get; set; }
        public string InventoryName { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public DateTime? ExpiredDate { get; set; }
    }
}
