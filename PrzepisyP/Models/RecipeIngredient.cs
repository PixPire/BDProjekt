using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrzepisyP.Models
{
    public class RecipeIngredient
    {
        public string RecipeId { get; set; }
        public string IngredientId { get; set; }
        [Required]
        public int Quantity { get; set; }

        public Recipe Recipe { get; set; }
        public Ingredient Ingredient { get; set; }
    }
}
