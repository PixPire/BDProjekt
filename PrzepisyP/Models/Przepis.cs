using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PrzepisyP.Models
{
    public class Przepis
    {
        [Key]
        [Display(Name = "Id")]
        public int Id { get; set; }
        [Display(Name = "Nazwa")]
        public string Nazwa { get; set; }
        [Display(Name = "Opis")]
        public string Opis { get; set; }
        [Display(Name = "Uzytkownik")]
        public string Uzytkownik { get; set; }
        [Display(Name = "Data publikacji")]
        public string Data_publikacji { get; set; }
        [Display(Name = "Skladniki")]
        public string Skladniki { get; set; }
        [Display(Name = "Likes")]
        public int Likes { get; set; }
    }
}
