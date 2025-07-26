using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceriesApp.Shared
{
    public class RecipeItem
    {
        public int Id { get; set; }
        public int RecipeId { get; set; }
        public Recipe Recipe { get; set; } = new Recipe();
        public int IngredientId { get; set; }
        public Ingredient Ingredient { get; set; } = new Ingredient();
        public decimal AmountRequired { get; set; }
    }
}
