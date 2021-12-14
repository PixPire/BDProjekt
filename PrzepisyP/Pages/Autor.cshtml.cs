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
    public class AutorModel : PageModel
    {
        IPrzepisyDb przepisyDb;
        public List<Przepis> przepisy;
        private readonly ILogger<AutorModel> _logger;
        public string _nazwa;
        public string wyszukajNazwaUzytkownika { get; set; }
        public AutorModel(ILogger<AutorModel> logger, IPrzepisyDb przepisyDb)
        {
            _logger = logger;
            this.przepisyDb = przepisyDb;
        }

        public void OnGet(string nazwa)
        {
            _nazwa = nazwa;
            przepisy = przepisyDb.SzukajPoUzytkowniku(nazwa);
        }
    }
}
