using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace restbe.Models
{
    public class GinModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int GinBrandId { get; set; }
        public GinBrands GinBrand { get; set; }
    }
}
