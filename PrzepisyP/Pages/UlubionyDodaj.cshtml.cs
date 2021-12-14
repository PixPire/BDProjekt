using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using PrzepisyP.Data;

namespace PrzepisyP.Pages
{
    public class UlubionyDodajModel : PageModel
    {
        IPrzepisyDb przepisyDb;
        private readonly ILogger<UlubionyDodajModel> _logger;

        public UlubionyDodajModel(ILogger<UlubionyDodajModel> logger, IPrzepisyDb przepisyDb)
        {
            _logger = logger;
            this.przepisyDb = przepisyDb;
        }

        public IActionResult OnGet(int id, string nazwa)
        {
            przepisyDb.AddUlubiony(id, nazwa);
            return RedirectToPage("PrzepisDetails", new { id = id });
        }
    }
}
