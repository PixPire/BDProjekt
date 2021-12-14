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
    public class PrzepisyDb : IPrzepisyDb
    {
        private string configuration;

        public void Add(Przepis przepis)
        {
            SqlConnection con = new SqlConnection(configuration);
            string sql = "sp_createPrzepis";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", przepis.Id);
            cmd.Parameters.AddWithValue("@nazwa", przepis.Nazwa);
            cmd.Parameters.AddWithValue("@opis", przepis.Opis);
            cmd.Parameters.AddWithValue("@uzytkownik", przepis.Uzytkownik);
            cmd.Parameters.AddWithValue("@skladniki", przepis.Skladniki);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void Delete(int id)
        {
            SqlConnection con = new SqlConnection(configuration);
            string sql = "sp_deletePrzepis";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public Przepis Get(int id)
        {
            Przepis przepis = null;
            SqlConnection con = new SqlConnection(configuration);
            string sql = "sp_getPrzepis";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                przepis = new Przepis();
                przepis.Id = int.Parse(reader["Id"].ToString());
                przepis.Nazwa = reader["Nazwa"].ToString();
                przepis.Opis = reader["Opis"].ToString();
                przepis.Uzytkownik = reader["Uzytkownik"].ToString();
                przepis.Data_publikacji = reader["Data_publikacji"].ToString();
                przepis.Skladniki = reader["Skladniki"].ToString();
                przepis.Likes = int.Parse(reader["likes"].ToString());
            }
            reader.Close(); con.Close();
            con.Close();
            return przepis;
        }

        public List<Przepis> List()
        {
            List<Przepis> przepisy = new List<Przepis>();
            Przepis przepis;
            SqlConnection con = new SqlConnection(configuration);
            string sql = "sp_selectPrzepis";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                przepis = new Przepis();
                przepis.Id = int.Parse(reader["Id"].ToString());
                przepis.Nazwa = reader["Nazwa"].ToString();
                przepis.Opis = reader["Opis"].ToString();
                przepis.Uzytkownik = reader["Uzytkownik"].ToString();
                przepis.Data_publikacji = reader["Data_publikacji"].ToString();
                przepis.Skladniki = reader["Skladniki"].ToString();
                przepisy.Add(przepis);
            }
            reader.Close(); con.Close();
            return przepisy;
        }
        
        public List<Przepis> ListUlubione(string nazwaUzytkownika)
        {
            List<Przepis> przepisy = new List<Przepis>();
            Przepis przepis;
            SqlConnection con = new SqlConnection(configuration);
            string sql = "sp_selectUlubione";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@nazwauzytkownika", nazwaUzytkownika);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                przepis = new Przepis();
                przepis.Id = int.Parse(reader["Id"].ToString());
                przepis.Nazwa = reader["Nazwa"].ToString();
                przepis.Opis = reader["Opis"].ToString();
                przepis.Uzytkownik = reader["Uzytkownik"].ToString();
                przepis.Data_publikacji = reader["Data_publikacji"].ToString();
                przepis.Skladniki = reader["Skladniki"].ToString();
                przepisy.Add(przepis);
            }
            reader.Close(); con.Close();
            return przepisy;
        }

        public void Update(Przepis przepis)
        {
            SqlConnection con = new SqlConnection(configuration);
            string sql = "sp_updatePrzepis";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", przepis.Id);
            cmd.Parameters.AddWithValue("@nazwa", przepis.Nazwa);
            cmd.Parameters.AddWithValue("@opis", przepis.Opis);
            cmd.Parameters.AddWithValue("@skladniki", przepis.Skladniki);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public PrzepisyDb(IConfiguration configuration) 
        {
            this.configuration = configuration.GetConnectionString("DefaultConnection");
        }

        public int GetNextId()
        {
            Przepis przepis = new Przepis();
            List<Przepis> przepisy = List();
            if (przepisy.Count == 0) return 1;
            przepis = przepisy[przepisy.Count - 1];
            return przepis.Id;
        }

        public List<string> GetSkladniki(string skladniki)
        {
            List<string> lista = skladniki.Split(';').ToList();
            lista.RemoveAt(lista.Count - 1);
            return lista;
        }

        public string SetSkladniki(List<string> skladniki)
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach(var item in skladniki)
            {
                stringBuilder.Append(item);
                stringBuilder.Append(";");
            }
            return stringBuilder.ToString();
        }

        public void DeleteUlubiony(int id, string nazwa)
        {
            SqlConnection con = new SqlConnection(configuration);
            string sql = "sp_deleteUlubione";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idprzepisu", id);
            cmd.Parameters.AddWithValue("@nazwauzytkownika", nazwa);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void AddUlubiony(int id, string nazwa)
        {
            SqlConnection con = new SqlConnection(configuration);
            string sql = "sp_createUlubione";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idprzepisu", id);
            cmd.Parameters.AddWithValue("@nazwauzytkownika", nazwa);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public List<Przepis> Szukaj(string nazwa, string uzytkownik)
        {
            List<Przepis> przepisy = new List<Przepis>();
            Przepis przepis;
            SqlConnection con = new SqlConnection(configuration);
            string sql;
            SqlCommand cmd;
            if(nazwa!=null)
            {
                sql = "sp_selectSzukajNazwa";
                cmd = new SqlCommand(sql, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nazwa", nazwa);
            }
            else
            {
                sql = "sp_selectSzukajUzytkownik";
                cmd = new SqlCommand(sql, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@uzytkownik", uzytkownik);
            }
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                przepis = new Przepis();
                przepis.Id = int.Parse(reader["Id"].ToString());
                przepis.Nazwa = reader["Nazwa"].ToString();
                przepis.Opis = reader["Opis"].ToString();
                przepis.Uzytkownik = reader["Uzytkownik"].ToString();
                przepis.Data_publikacji = reader["Data_publikacji"].ToString();
                przepis.Skladniki = reader["Skladniki"].ToString();
                przepisy.Add(przepis);
            }
            reader.Close(); con.Close();
            return przepisy;
        }

        public List<Przepis> SzukajPoUzytkowniku(string nazwa)
        {
            List<Przepis> przepisy = new List<Przepis>();
            Przepis przepis;
            SqlConnection con = new SqlConnection(configuration);
            string sql = "sp_selectSzukajPoUzytkowniku";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@uzytkownik", nazwa);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                przepis = new Przepis();
                przepis.Id = int.Parse(reader["Id"].ToString());
                przepis.Nazwa = reader["Nazwa"].ToString();
                przepis.Opis = reader["Opis"].ToString();
                przepis.Uzytkownik = reader["Uzytkownik"].ToString();
                przepis.Data_publikacji = reader["Data_publikacji"].ToString();
                przepis.Skladniki = reader["Skladniki"].ToString();
                przepisy.Add(przepis);
            }
            reader.Close(); con.Close();
            return przepisy;
        }

        public List<Przepis> Top()
        {
            List<Przepis> przepisy = new List<Przepis>();
            Przepis przepis;
            SqlConnection con = new SqlConnection(configuration);
            string sql = "sp_selectTop";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                przepis = new Przepis();
                przepis.Id = int.Parse(reader["Id"].ToString());
                przepis.Nazwa = reader["Nazwa"].ToString();
                przepis.Opis = reader["Opis"].ToString();
                przepis.Uzytkownik = reader["Uzytkownik"].ToString();
                przepis.Data_publikacji = reader["Data_publikacji"].ToString();
                przepis.Skladniki = reader["Skladniki"].ToString();
                przepisy.Add(przepis);
            }
            reader.Close(); con.Close();
            return przepisy;
        }
        public int checkLike(int id, string nazwa)
        {
            Przepis przepis=null;
            SqlConnection con = new SqlConnection(configuration);
            string sql = "sp_checkLike";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idprzepisu", id);
            cmd.Parameters.AddWithValue("@nazwauzytkownika", nazwa);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                przepis = new Przepis();
                przepis.Id = int.Parse(reader["IdPrzepisu"].ToString());
            }
            reader.Close(); con.Close();
            return (przepis != null) ? 1 : 0;
        }
        public void addLike(int id, string nazwa)
        {
            SqlConnection con = new SqlConnection(configuration);
            string sql = "sp_addLike";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idprzepisu", id);
            cmd.Parameters.AddWithValue("@nazwauzytkownika", nazwa);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void LikeOrDislike(int stan, int id, string nazwa)
        {
            if(checkLike(id,nazwa)==0)
            {
                addLike(id, nazwa);
                SqlConnection con = new SqlConnection(configuration);
                string sql = "sp_updateLike";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idprzepisu", id);
                cmd.Parameters.AddWithValue("@stan", stan);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
