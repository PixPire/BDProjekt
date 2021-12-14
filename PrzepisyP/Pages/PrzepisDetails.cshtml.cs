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
    public class PrzepisDetailsModel : PageModel
    {
        IPrzepisyDb przepisDb;
        [BindProperty]
        public Przepis przepis { get; set; }
        private readonly ILogger<PrzepisDetailsModel> _logger;
        public List<string> skladniki { get; set; }
        public List<Przepis> ulubione { get; set; }
        public int oddanyLike;
        public int ulubiony;
        public PrzepisDetailsModel(ILogger<PrzepisDetailsModel> logger, IPrzepisyDb przepisDb)
        {
            _logger = logger;
            this.przepisDb = przepisDb;
        }
        public void OnGet(int id)
        {
            przepis = przepisDb.Get(id);
            skladniki = przepisDb.GetSkladniki(przepis.Skladniki);
            ulubiony = 0;
            oddanyLike = 1;
            if (User.Identity.IsAuthenticated)
            {
                 ulubione = przepisDb.ListUlubione(User.Identity.Name);
                 foreach(var item in ulubione)
                 {
                     if (item.Id == id) ulubiony = 1;
                 }
                 oddanyLike = przepisDb.checkLike(id, User.Identity.Name);

            }
            
        }
        public IActionResult OnPost()
        {
            return RedirectToPage("PrzepisManage");
        }
    }
}
