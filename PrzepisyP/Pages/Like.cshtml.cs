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
    public class LikeModel : PageModel
    {
        IPrzepisyDb przepisyDb;
        private readonly ILogger<LikeModel> _logger;

        public LikeModel(ILogger<LikeModel> logger, IPrzepisyDb przepisyDb)
        {
            _logger = logger;
            this.przepisyDb = przepisyDb;
        }

        public IActionResult OnGet(int like,int id)
        {
            przepisyDb.LikeOrDislike(like, id, User.Identity.Name);
            return RedirectToPage("PrzepisDetails", new { id = id });
        }
    }
}
