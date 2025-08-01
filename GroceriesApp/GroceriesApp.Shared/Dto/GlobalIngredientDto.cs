using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceriesApp.Shared
{
    public class GlobalIngredientDto
    {
        public int? Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public IngredientCategory Category { get; set; }
        public IngredientUnitType UnitType { get; set; }
        public decimal DefaultAmount { get; set; }
        public List<IngredientPriceDto>? Prices { get; set; }

        public Ingredient ConvertFromIngredientDto(GlobalIngredientDto ingredient)
        {
            return new Ingredient
            {
                Name = ingredient.Name,
                Category = ingredient.Category,
                UnitType = ingredient.UnitType,
                DefaultAmount = ingredient.DefaultAmount,
                IngredientPrices = ingredient.Prices?
                    .Select(p => new IngredientPrice
                    {
                        Currency = p.Currency,
                        Price = p.Price
                    }).ToList()
            };
        }
    }
}
