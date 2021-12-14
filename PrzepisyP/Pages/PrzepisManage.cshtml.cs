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
    public class PrzepisManageModel : PageModel
    {
        IPrzepisyDb przepisyDb;
        public List<Przepis> przepisy;
        [BindProperty(SupportsGet = true)]
        public string wyszukajNazwaPrzepisu { get; set; }
        [BindProperty(SupportsGet = true)]
        public string wyszukajNazwaUzytkownika { get; set; }
        private readonly ILogger<PrzepisManageModel> _logger;

        public PrzepisManageModel(ILogger<PrzepisManageModel> logger, IPrzepisyDb przepisyDb)
        {
            _logger = logger;
            this.przepisyDb = przepisyDb;
        }

        public void OnGet()
        {
            przepisy = przepisyDb.List();
        }

        public IActionResult OnPostSzukaj()
        {

            return RedirectToPage("Szukaj", new { wyszukajNazwaPrzepisu = wyszukajNazwaPrzepisu, wyszukajNazwaUzytkownika = wyszukajNazwaUzytkownika });
        }
    }
}
