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
    public class CommentCreateModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public Comment comment { get; set; }
        [BindProperty(SupportsGet = true)]
        public string tresc { get; set; }
       
        ICommentsDb commentsDb;
        public List<Comment> comments;
        private readonly ILogger<CommentCreateModel> _logger;

        public CommentCreateModel(ILogger<CommentCreateModel> logger, ICommentsDb commentsDb)
        {
            _logger = logger;
            this.commentsDb = commentsDb;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            comment.NazwaUzytkownika = User.Identity.Name;
            comment.Id = commentsDb.GetNextId() + 1;
   
            commentsDb.Add(comment);
            return RedirectToPage("PrzepisDetails");
        }
    }

}
