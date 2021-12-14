using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PrzepisyP.Models;

namespace PrzepisyP.Data
{
    public interface IPrzepisyDb
    {
        public List<Przepis> List();

        public void Update(Przepis przepis);
        
        public void Delete(int id);

        public void Add(Przepis przepis);

        public Przepis Get(int id);

        public int GetNextId();

        public List<string> GetSkladniki(string skladniki);

        public string SetSkladniki(List<string> skladniki);

        public List<Przepis> ListUlubione(string nazwaUzytkownika);

        public void DeleteUlubiony(int id,string nazwa);

        public void AddUlubiony(int id, string nazwa);

        public List<Przepis> Szukaj(string nazwa, string uzytkownik);

        public List<Przepis> SzukajPoUzytkowniku(string nazwa);

        public List<Przepis> Top();

        public void LikeOrDislike(int stan, int id, string nazwa);
        public int checkLike(int id, string nazwa);
    }
}
