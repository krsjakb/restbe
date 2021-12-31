using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace restbe.Models
{
    public class PhoneUSBConnector
    {
        public int Id { get; set; }

        public int Id_phone { get; set; }
        public Phone Phone { get; set; }

        public int Id_USBConnector { get; set; }
        public USBConnector USBConnector { get; set; }
    }
}
