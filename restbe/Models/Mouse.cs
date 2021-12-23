using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace restbe.Models
{
    public class Mouse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public int maxDPI { get; set; }
        public int minDPI { get; set; }
    }
}
