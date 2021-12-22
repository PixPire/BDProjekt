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
    public class PrzepisDeleteModel : PageModel
    {
    
        IPrzepisyDb przepisyDb;
        public List<Przepis> przepisy;
        private readonly ILogger<PrzepisDeleteModel> _logger;

        public PrzepisDeleteModel(ILogger<PrzepisDeleteModel> logger, IPrzepisyDb przepisyDb)
        {
            _logger = logger;
            this.przepisyDb = przepisyDb;
        }

        public IActionResult OnGet(int id)
        {
            przepisyDb.Delete(id);
            return RedirectToPage("PrzepisManage");
        }
        
    }
}
