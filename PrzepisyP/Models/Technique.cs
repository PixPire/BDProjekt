using System.ComponentModel.DataAnnotations;

namespace PrzepisyP.Models
{
    public class Technique
    {
        [Key]
        public string Id { get; set; }
        [Required]
        public int difficulty { get; set; }
    }
}
