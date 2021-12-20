using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace restbe.Models
{
    public class MonitorModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CabinetColor { get; set; }
        public int RefreshRate { get; set; }
        public float ResponseTime { get; set; }
        public float ScreenSize { get; set; }
        public MonitorBrand MonitorBrand { get; set; }
    }
}
