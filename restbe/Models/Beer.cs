using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace restbe.Models
{
    public class Beer
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public int AlcoholPercentage { get; set; }
        public int Rating { get; set; }
    }
}
