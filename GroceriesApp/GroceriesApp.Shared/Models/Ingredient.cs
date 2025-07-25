using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceriesApp.Shared
{
    public class Ingredient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Category { get; set; }
        public IngredientUnitType UnitType { get; set; }
        public decimal Amount { get; set; }
        public List<IngredientPrice> Prices { get; set; }
    }
}
