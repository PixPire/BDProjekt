using Microsoft.AspNetCore.Identity;

namespace PrzepisyP.Models
{
    public class AccesoryFavourite
    {
        public int AccesoryId { get; set; }
        public int UserId { get; set; }

        public Accesory Accesory { get; set; }
        public IdentityUser User { get; set; }
    }
}
