using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PrzepisyP.Models
{
    public class Comment
    {
        [Key]
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "IdArtykulu")]
        public int IdArtykulu { get; set; }

        [Display(Name = "Tresc")]
        public string Tresc { get; set; }

        [Display(Name = "NazwaUzytkownika")]
        public string NazwaUzytkownika { get; set; }

        [Display(Name = "Data publikacji")]
        public string Data_publikacji { get; set; }

    }
}

