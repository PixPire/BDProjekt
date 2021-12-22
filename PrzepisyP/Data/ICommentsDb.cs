using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PrzepisyP.Models;

namespace PrzepisyP.Data
{
    public interface ICommentsDb
    {
        public List<Comment> List(int idPrzepisu);

        public void Update(Comment comment);

        public void Delete(int id);

        public void Add(Comment comment);

        public Comment Get(int id);

        public int GetNextId();

        

    }
}
