using PrzepisyP.Models;
using System.Collections.Generic;

namespace PrzepisyP.Data
{
    public interface IRecipesDB
    {
        //Returns a list of all recipes
        public List<Recipe> List();

        //Updates a recipe, the recipe to update is based on the id of recipe given as parameter
        public void Update(Recipe recipe);

        //Deletes a recipe with given id number
        public void Delete(string id);

        //Adds a recipe to the database
        public void Add(Recipe recipe);

        //Returns a recipe with an id number given as parameter
        public Recipe Get(string id);

        //Returns a list of recipes determined by a search phrase
        public List<Recipe> Search(string searchPhrase);

        //Returns a list of recipes determined by a given username(Similar to Search() but used for usernames)
        public List<Recipe> SearchByUser(string username);

        //Returns a list of top recipes determined by some value, not sure if necessary, implement if you feel like it 
        public List<Recipe> Top();
    }
}
