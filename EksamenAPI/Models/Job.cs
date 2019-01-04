using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EksamenAPI.Models
{
    public class Job
    {
        // Primary key
        public int JobId { get; set; }

        public string Customer { get; set; }
        public string StartDate { get; set; }
        public int NumberOfDays { get; set; }
        public string Location { get; set; }
        public int NumberOfModels { get; set; }
        public string Comments { get; set; }
    }
}
