using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using PrzepisyP.Models;

namespace PrzepisyP.Data
{
    public class CommentsDb
    {
        private string configuration;

        public void Add(Comment comment)
        {
            SqlConnection con = new SqlConnection(configuration);
            string sql = "sp_createComment";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", comment.Id);
            cmd.Parameters.AddWithValue("@idArtykulu", comment.IdArtykulu);
            cmd.Parameters.AddWithValue("@tresc", comment.Tresc);
            cmd.Parameters.AddWithValue("@nazwaUzytkownika", comment.NazwaUzytkownika);
            cmd.Parameters.AddWithValue("@dataPublikacji", comment.Data_publikacji);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void Delete(int id)
        {
            SqlConnection con = new SqlConnection(configuration);
            string sql = "sp_deleteComment";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public Comment Get(int id)
        {
            Comment comment = null;
            SqlConnection con = new SqlConnection(configuration);
            string sql = "sp_getComment";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                comment = new Comment();
                comment.Id = int.Parse(reader["Id"].ToString());
                comment.IdArtykulu = int.Parse(reader["idArtykulu"].ToString());
                comment.Tresc = reader["tresc"].ToString();
                comment.NazwaUzytkownika = reader["nazwaUzytkownika"].ToString();
                comment.Data_publikacji = reader["dataPublikacji"].ToString();
            }
            reader.Close(); con.Close();
            con.Close();
            return comment;
        }

        public List<Comment> List()
        {
            List<Comment> comments = new List<Comment>();
            Comment comment;
            SqlConnection con = new SqlConnection(configuration);
            string sql = "sp_selectComment";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                comment = new Comment();
                comment.Id = int.Parse(reader["Id"].ToString());
                comment.IdArtykulu = int.Parse(reader["idArtykulu"].ToString());
                comment.Tresc = reader["tresc"].ToString();
                comment.NazwaUzytkownika = reader["nazwaUzytkownika"].ToString();
                comment.Data_publikacji = reader["dataPublikacji"].ToString();
                comments.Add(comment);
            }
            reader.Close(); con.Close();
            return comments;
        }

        

        public void Update(Comment comment)
        {
            SqlConnection con = new SqlConnection(configuration);
            string sql = "sp_updateComment";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", comment.Id);
            cmd.Parameters.AddWithValue("@nazwa", comment.Tresc);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public CommentsDb(IConfiguration configuration)
        {
            this.configuration = configuration.GetConnectionString("DefaultConnection");
        }

        public int GetNextId()
        {
            Comment comment = new Comment();
            List<Comment> comments = List();
            if (comments.Count == 0) return 1;
            comment = comments[comments.Count - 1];
            return comment.Id;
        }

        

      
        
    }
}
