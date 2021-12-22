using System.ComponentModel.DataAnnotations;

namespace PrzepisyP.Models
{
    public class Accesory
    {
        [Key]
        public string Id { get; set; }
        [Required]
        public float Price { get; set; }
    }
}
