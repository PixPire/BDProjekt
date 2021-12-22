using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrzepisyP.Models
{
    public class RecipeCategoryJoin
    {
        public string RecipeId { get; set; }
        public string CategoryId { get; set; }

        public Recipe Recipe { get; set; }
        public RecipeCategory Category { get; set; }
    }
}
