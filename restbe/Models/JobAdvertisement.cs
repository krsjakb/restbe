using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace restbe.Models
{
    public class JobAdvertisement
    {
        public int Id { get; set; }
        public String name { get; set; }
        public String text { get; set; }
        public String location { get; set; }
    }
}
