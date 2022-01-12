using System.ComponentModel.DataAnnotations;

namespace PrzepisyP.Models
{
    public class Ingredient
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
