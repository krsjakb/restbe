using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace restapi.Models
{
    public class Couch
    {
        public int Id { get; set; }
        public int Weight { get; set; }
        public string BrandName { get; set; }
        public string Material { get; set; }
    }
}
