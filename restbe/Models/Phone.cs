using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace restbe.Models
{
    public class Phone
    {
        public int Id { get; set; }
        public int Price { get; set; }
        public string BrandName { get; set; }
        public string TypeName { get; set; }
        public virtual ICollection<PhoneUSBCompatibility> USBCompatibility { get; set; }
    }
}
