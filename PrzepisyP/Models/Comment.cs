using System;
using System.ComponentModel.DataAnnotations;

namespace PrzepisyP.Models
{
    public class Comment
    {
        [Key]
        public string Id { get; set; }
        public string OwnerId { get; set; }
        public string ArticleId { get; set; }
        [Required]
        public string TextContent { get; set; }
        public DateTime PublishDate { get; set; }
    }
}
