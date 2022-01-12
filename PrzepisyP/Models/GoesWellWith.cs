using System.ComponentModel.DataAnnotations;

namespace PrzepisyP.Models
{
    public class GoesWellWith
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
