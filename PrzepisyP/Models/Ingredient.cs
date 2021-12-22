using System.ComponentModel.DataAnnotations;

namespace PrzepisyP.Models
{
    public class Ingredient
    {
        [Key]
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
