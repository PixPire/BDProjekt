using PrzepisyP.Models;
using System.Collections.Generic;

namespace PrzepisyP.Data
{
    public interface IArticlesDB
    {
        //Returns a list of all articles
        public List<Article> List();

        //Adds given article to database
        public void Add(Article article);

        //Updates an article, the article to update is based on the id of article given as parameter
        public void Update(Article article);

        //Deletes an article with a given id string
        public void Delete(string articleId);

        public Article GetById(int id);

        //Generates a new id string
        public string GetNextId();

        //Returns string value representing what the article represents
        //ex. "recipe", "technique", "accesory"
        public string GetContentType(string id);
    }
}
