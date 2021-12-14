using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrzepisyP.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
     

    }
}
