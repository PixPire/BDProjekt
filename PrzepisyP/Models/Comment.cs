using System;

namespace PrzepisyP.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public int OwnerId { get; set; }
        public int ArticleId { get; set; }
        public string TextContent { get; set; }
        public DateTime PublishDate { get; set; }
    }
}
