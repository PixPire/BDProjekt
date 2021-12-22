using Microsoft.AspNetCore.Identity;
using System;

namespace PrzepisyP.Models
{
    public class Article
    {
        public int Id { get; set; }
        public string OwnerId { get; set; }
        public string Name { get; set; }
        public string TextContent { get; set; }
        public DateTime PublishDate { get; set; }
        public int Rating { get; set; }

        public IdentityUser Owner { get; set; }
    }
}
