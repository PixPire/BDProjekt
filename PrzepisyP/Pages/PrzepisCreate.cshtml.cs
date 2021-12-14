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
    public class PrzepisCreateModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public Przepis przepis { get; set; }
        [BindProperty(SupportsGet = true)]
        public List<string> skladniki { get; set; }
        [BindProperty(SupportsGet = true)]
        public string skladnik { get; set; }
        IPrzepisyDb przepisyDb;
        public List<Przepis> przepisy;
        private readonly ILogger<PrzepisCreateModel> _logger;

        public PrzepisCreateModel(ILogger<PrzepisCreateModel> logger, IPrzepisyDb przepisyDb)
        {
            _logger = logger;
            this.przepisyDb = przepisyDb;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            przepis.Uzytkownik = User.Identity.Name;
            przepis.Id = przepisyDb.GetNextId() + 1;
            if (skladnik != null) skladniki.Add(skladnik);
            przepis.Skladniki = przepisyDb.SetSkladniki(skladniki);
            przepisyDb.Add(przepis);
            return RedirectToPage("PrzepisManage");
        }
    }

}
