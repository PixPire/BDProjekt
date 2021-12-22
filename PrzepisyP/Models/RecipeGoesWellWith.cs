using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrzepisyP.Models
{
    public class RecipeGoesWellWith
    {
        public string RecipeId { get; set; }
        public string GoesWellWithId { get; set; }

        public Recipe Recipe { get; set; }
        public GoesWellWith GoesWellWith { get; set; }
    }
}
