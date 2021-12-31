using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace restbe.Models
{
    public class WhiskeyBrands
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Origin { get; set; }
        public virtual ICollection<WhiskeyModel> WhiskeyModels { get; set; }
    }
}
