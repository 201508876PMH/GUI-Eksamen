using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EksamenAPI.Models
{
    public class Assignment
    {
        // Primary key
        public int AssignmentId { get; set; }

        public string ModelName { get; set; }
        public string Customer { get; set; }
    }
}
