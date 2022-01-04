using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace restbe.Models
{
    public class ELiquid
    {
        public int ID { get; set; }

        public string FName { get; set; }

        public int Str { get; set; }

        public ELiquid Eliquid { get; set; }
    }
}
