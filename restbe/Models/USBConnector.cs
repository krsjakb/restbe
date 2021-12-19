using System.Collections.Generic;

namespace restbe.Models
{
    public enum EPlugType
    {
        Micro,
        Type_C,
        Lightning
    }

    public class USBConnector
    {
        public int Id { get; set; }
        public string Id_Material { get; set; }
        public string Id_Production { get; set; }
        public double Amperage { get; set; }
        public double Voltage { get; set; }
        public EPlugType PlugType { get; set; }
        public virtual ICollection<PhoneUSBCompatibility> PhoneCompatibility { get; set; }
    }
}
