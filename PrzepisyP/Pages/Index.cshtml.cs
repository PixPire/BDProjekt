using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PrzepisyP.Data;
using PrzepisyP.Models;

namespace PrzepisyP.Pages.Users
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db; 

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public List<IdentityUser> ApplicationUserList { get; set; }

        public async Task<IActionResult> OnGet()
        {
            ApplicationUserList = await _db.Users.ToListAsync();
            return Page();
        }
    }
}
