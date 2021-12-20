using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace restbe.Models
{
    public class Jobs
    {
        public long Id { get; set; }
        public string JobName { get; set; }
        public string JobText { get; set; }
        public int JobPrice { get; set; }
    }
}
