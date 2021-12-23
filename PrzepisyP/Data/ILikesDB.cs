namespace PrzepisyP.Data
{
    public interface ILikesDB
    {
        //Checks whether the recipe is liked by a user or not
        public bool LikedBy(string recipeId, string userId);

        //Changes whether user likes or dislikes a recipe, sort of a toggle
        public void LikeToggle(string recipeId, string userId);
    }
}
