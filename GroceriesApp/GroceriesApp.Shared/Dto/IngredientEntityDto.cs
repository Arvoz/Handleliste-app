using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceriesApp.Shared
{
    public class IngredientEntityDto
    {
        public GlobalIngredientDto? Ingredient { get; set; }
        public IngredientPriceDto? IngredientPrice { get; set; }

        public Ingredient ConvertFromIngredientDto(GlobalIngredientDto ingredient)
        {
            return new Ingredient
            {
                Name = ingredient.Name,
                Category = ingredient.Category,
                UnitType = ingredient.UnitType,
                DefaultAmount = ingredient.DefaultAmount
            };
        }

        public IngredientPrice ConvertFromIngredientPriceDto(IngredientPriceDto ingredientPrice)
        {
            return new IngredientPrice
            {
                Currency = ingredientPrice.Currency,
                Price = ingredientPrice.Price

            };
        }

    }
}
