using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace restbe.Models
{
    public class PlugType
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<USBConnector> USBConnectors { get; set; }
    }
}
