using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EksamenWPF_WEB.Models
{
    public class Model
    {
        // Primary key
        public int ModelId { get; set; }

        public string Name { get; set; }
        public string TelephoneNumber { get; set; }
        public string Address { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public string HairColor { get; set; }
        public string Comments { get; set; }
    }
}
