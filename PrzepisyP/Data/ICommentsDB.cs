using PrzepisyP.Models;
using System.Collections.Generic;

namespace PrzepisyP.Data
{
    public interface ICommentsDB
    {
        //Returns a list of all comments for a given article
        public List<Comment> GetFromArticle(string articleId);

        //Returns a list of all comments for a given user
        public List<Comment> GetFromUser(string userId);

        //Adds a comment to database
        public void Add(Comment comment);

        //Updates a comment, the comment to update is based on the id of comment given as parameter
        public void Update(Comment comment);

        //Deletes a comment with a given id string
        public void Delete(string commentId);
    }
}
