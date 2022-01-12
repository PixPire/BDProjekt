using System;
using System.ComponentModel.DataAnnotations;

namespace PrzepisyP.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        public int OwnerId { get; set; }
        public int ArticleId { get; set; }
        [Required]
        public string TextContent { get; set; }
        public DateTime PublishDate { get; set; }
    }
}
