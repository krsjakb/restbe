namespace restbe.Models
{
    public class PhoneUSBCompatibility
    {
        public int Id { get; set; }
        public Phone Phone { get; set; }
        public USBConnector USBConnector { get; set; }
    }
}
