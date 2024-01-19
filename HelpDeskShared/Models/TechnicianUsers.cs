using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDeskShared.Models
{
    public class TechnicianUsers
    {
        public int userid { get; set; }
        public string? firstname { get; set; }
        public int employeeid { get; set; }
        public string? jobtitle { get; set; }
        public string? status { get; set; }
        public int? reportingto { get; set; }
    }
}
