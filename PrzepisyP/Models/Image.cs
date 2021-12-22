using Microsoft.AspNetCore.Http;

namespace PrzepisyP.Models
{
    public class Image
    {
        public int Id { get; set; }
        public bool IsDefault { get; set; }
        public int ArticleId { get; set; }
        public IFormFile ImageFile { get; set; }

        public Article Article { get; set; }
    }
}
