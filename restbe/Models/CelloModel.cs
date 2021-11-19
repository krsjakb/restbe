using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace restbe.Models
{
    public class CelloModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CelloBrandId { get; set; }
        public CelloBrands CelloBrand { get; set; }
    }
}
