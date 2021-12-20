using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace restbe.Models
{
    public class MonitorBrand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Place { get; set; }
        public virtual ICollection<MonitorModel> MonitorModels { get; set; }
    }
}
