using System.ComponentModel.DataAnnotations;

namespace PrzepisyP.Models
{
    public class Technique
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int difficulty { get; set; }
    }
}
