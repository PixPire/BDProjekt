using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace PrzepisyP.Models
{
    public class Article
    {
        [Key]
        public string Id { get; set; }
        public string OwnerId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string TextContent { get; set; }
        [Required]
        public DateTime PublishDate { get; set; }
        public int Rating { get; set; }

        public IdentityUser Owner { get; set; }
    }
}
