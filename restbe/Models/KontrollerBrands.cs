using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace restbe.Models
{
    public class KontrollerBrands
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public string Color { get; set; }
        public string Compatibility { get; set; }
        public virtual ICollection<KontrollerBrands> KontrollerModels { get; set; }
    }
}
