using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrzepisyP.Models
{
    public class PrzepisIAutor
    {
        public ApplicationUser UserObject { get; set; }
        public IEnumerable<Przepis> Przepisy { get; set; }

    }
}
