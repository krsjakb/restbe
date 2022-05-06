using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace restbe.Models
{
    public class BlanketModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public string MainColor { get; set; }
        public string MainMaterial { get; set; }
        public int Width { get; set; }
        public int Length { get; set; }
        
    }
}
