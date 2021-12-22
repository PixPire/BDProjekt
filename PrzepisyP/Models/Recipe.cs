using System.ComponentModel.DataAnnotations;

namespace PrzepisyP.Models
{
    public class Recipe
    {
        [Key]
        public string Id { get; set; }
        [Required]
        public int PreparationTime { get; set; }
    }
}
