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
    public class PrzepisEditModel : PageModel
    {
        IPrzepisyDb przepisDb;
        [BindProperty]
        public Przepis przepis { get; set; }
        private readonly ILogger<PrzepisEditModel> _logger;

        public PrzepisEditModel(ILogger<PrzepisEditModel> logger, IPrzepisyDb przepisDb)
        {
            _logger = logger;
            this.przepisDb = przepisDb;
        }
        public void OnGet(int id)
        {
            przepis = przepisDb.Get(id);
        }
        public IActionResult OnPost()
        {
            przepisDb.Update(przepis);
            return RedirectToPage("PrzepisManage");
        }
    }
}
