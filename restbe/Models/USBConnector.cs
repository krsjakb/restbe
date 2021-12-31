using System.Collections.Generic;

namespace restbe.Models
{
    public class USBConnector
    {
        public int Id { get; set; }
        public string Id_Material { get; set; }
        public string Id_Production { get; set; }
        public double Amperage { get; set; }
        public double Voltage { get; set; }

        public int Id_PlugType { get; set; }
        public PlugType PlugType { get; set; }
        public virtual ICollection<PhoneUSBConnector> PhoneUSBConnectors { get; set; }
    }
}
