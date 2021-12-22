namespace PrzepisyP.Models
{
    public class RecipeGoesWellWith
    {
        public int RecipeId { get; set; }
        public int GoesWellWithId { get; set; }

        public Recipe Recipe { get; set; }
        public GoesWellWith GoesWellWith { get; set; }
    }
}
