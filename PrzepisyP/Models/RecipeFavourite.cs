using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrzepisyP.Models
{
    public class RecipeFavourite
    {
        public string RecipeId { get; set; }
        public string UserId { get; set; }

        public Recipe Recipe { get; set; }
        public IdentityUser User { get; set; }
    }
}
