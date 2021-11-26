using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace restapi.Models
{
    public class Bed
    {
        public int Id { get; set; }
        public float Width { get; set; }
        public float Length{ get; set; }
        public float Height { get; set; }
        public string BrandName { get; set; }

    }
}
