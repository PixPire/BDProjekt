using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using PrzepisyP.Data;
using PrzepisyP.Models;

namespace PrzepisyP.Pages
{
    public class SzukajModel : PageModel
    {
        IPrzepisyDb przepisyDb;
        public List<Przepis> przepisy;
        private readonly ILogger<SzukajModel> _logger;
        public string wyszukajNazwaUzytkownika { get; set; }
        public SzukajModel(ILogger<SzukajModel> logger, IPrzepisyDb przepisyDb)
        {
            _logger = logger;
            this.przepisyDb = przepisyDb;
        }

        public void OnGet(string wyszukajNazwaPrzepisu, string wyszukajNazwaUzytkownika)
        {
            przepisy = przepisyDb.Szukaj(wyszukajNazwaPrzepisu, wyszukajNazwaUzytkownika);
        }
    }
}
