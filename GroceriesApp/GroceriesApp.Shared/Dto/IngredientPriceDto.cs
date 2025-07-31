using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceriesApp.Shared
{
    public class IngredientPriceDto
    {
        public int? IngredientId { get; set; }
        public PriceCurrency Currency { get; set; }
        public decimal Price { get; set; }
    }
}
