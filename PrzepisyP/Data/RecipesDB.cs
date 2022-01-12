using Microsoft.Extensions.Configuration;
using PrzepisyP.Models;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace PrzepisyP.Data
{
    public class RecipesDB : IRecipesDB
    {
        private string configuration;

        public RecipesDB(IConfiguration configuration)
        {
            this.configuration = configuration.GetConnectionString("DefaultConnection");
        }

        public void Add(Recipe recipe)
        {
            SqlConnection conn = new SqlConnection(configuration);
            string sql = 
                "@preparationTime " +
                "AS " +
                "INSERT INTO [dbo].[Recipes] (PreparationTime) " +
                "VALUES (@preparationTime)";
        }

        public void Delete(string id)
        {
            throw new System.NotImplementedException();
        }

        public Recipe Get(string id)
        {
            throw new System.NotImplementedException();
        }

        public List<Recipe> List()
        {
            throw new System.NotImplementedException();
        }

        public List<Recipe> Search(string searchPhrase)
        {
            throw new System.NotImplementedException();
        }

        public List<Recipe> SearchByUser(string username)
        {
            throw new System.NotImplementedException();
        }

        public List<Recipe> Top()
        {
            throw new System.NotImplementedException();
        }

        public void Update(Recipe recipe)
        {
            throw new System.NotImplementedException();
        }
    }
}
