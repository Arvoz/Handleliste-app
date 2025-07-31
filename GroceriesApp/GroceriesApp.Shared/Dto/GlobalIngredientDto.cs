using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceriesApp.Shared
{
    public class GlobalIngredientDto
    {
        public string Name { get; set; } = string.Empty;
        public IngredientCategory Category { get; set; }
        public IngredientUnitType UnitType { get; set; }
        public decimal DefaultAmount { get; set; }
    }
}
