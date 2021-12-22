﻿using Microsoft.AspNetCore.Identity;

namespace PrzepisyP.Models
{
    public class RecipeFacourite
    {
        public int RecipeId { get; set; }
        public int UserId { get; set; }

        public Recipe Recipe { get; set; }
        public IdentityUser User { get; set; }
    }
}
