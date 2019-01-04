using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace EksamenWPF_WEB.Models
{
    public class JobReport
    {
        // Primary Key
        public int JobReportId { get; set; }

        public string Job { get; set; }
        public DateTime Date { get; set; }
        public string Text { get; set; }
        public int Cost { get; set; }

        public int ModelId { get; set; }

        [ForeignKey("Id")]
        public Model Model { get; set; }
    }
}
