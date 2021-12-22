using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace PrzepisyP.Models
{
    public class Image
    {
        [Key]
        public string Id { get; set; }
        [Required]
        public bool IsDefault { get; set; }
        public string ArticleId { get; set; }
        [Required]
        public byte[] ImageFile { get; set; }

        public Article Article { get; set; }
    }
}
