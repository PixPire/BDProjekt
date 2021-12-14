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
    public class TwojePrzepisyManageModel : PageModel
    {
        IPrzepisyDb przepisyDb;
        public List<Przepis> przepisy;
        private readonly ILogger<TwojePrzepisyManageModel> _logger;

        public TwojePrzepisyManageModel(ILogger<TwojePrzepisyManageModel> logger, IPrzepisyDb przepisyDb)
        {
            _logger = logger;
            this.przepisyDb = przepisyDb;
        }

        public void OnGet()
        {
            przepisy = przepisyDb.List();
        }
    }
}
