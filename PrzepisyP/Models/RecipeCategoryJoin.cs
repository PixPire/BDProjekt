using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrzepisyP.Models
{
    public class RecipeCategoryJoin
    {
        public int RecipeId { get; set; }
        public int CategoryId { get; set; }

        public Recipe Recipe { get; set; }
        public RecipeCategory Category { get; set; }
    }
}
