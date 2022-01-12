using System.ComponentModel.DataAnnotations;

namespace PrzepisyP.Models
{
    public class Accesory
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public float Price { get; set; }
    }
}
