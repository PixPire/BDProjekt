using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PrzepisyP.Data;
using PrzepisyP.Models;

namespace PrzepisyP.Pages.Recipes
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Przepis> Przepis { get;set; }

        public async Task OnGetAsync()
        {
            Przepis = await _context.Przepis.ToListAsync();
        }
    }
}
