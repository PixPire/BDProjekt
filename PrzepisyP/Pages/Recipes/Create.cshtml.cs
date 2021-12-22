using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PrzepisyP.Data;
using PrzepisyP.Models;

namespace PrzepisyP.Pages.Recipes
{
    public class CreateModel : PageModel
    {
        private readonly PrzepisyP.Data.ApplicationDbContext _context;

        public CreateModel(PrzepisyP.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Przepis Przepis { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Przepis.Add(Przepis);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
