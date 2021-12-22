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
    public class DeleteModel : PageModel
    {
        private readonly PrzepisyP.Data.ApplicationDbContext _context;

        public DeleteModel(PrzepisyP.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Przepis Przepis { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Przepis = await _context.Przepis.FirstOrDefaultAsync(m => m.Id == id);

            if (Przepis == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Przepis = await _context.Przepis.FindAsync(id);

            if (Przepis != null)
            {
                _context.Przepis.Remove(Przepis);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
