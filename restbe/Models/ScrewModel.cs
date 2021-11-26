using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace restbe.Models
{
    public class ScrewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Material { get; set; }
        public string HeadType { get; set; }
        public double Length { get; set; }
        public string PackageSize { get; set; }
        public int Weight { get; set; }
        //public int ScrewBrandId { get; set; }
        //public ScrewBrands ScrewBrand { get; set; }
    }
}
