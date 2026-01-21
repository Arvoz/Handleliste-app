using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceriesApp.Shared
{
    public class CreateInventoryItemDto
    {
        public int IngredientId { get; set; }
        public int InventoryId { get; set; }
        public decimal Amount { get; set; }
        public DateTime? ExpiredDate { get; set; }
    }
}
