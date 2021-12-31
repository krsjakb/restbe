using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace restbe.Models
{
    public class WhiskeyModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int WhiskeyBrandId { get; set; }
        public WhiskeyBrands WhiskeyBrand { get; set; }
    }
}
