using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDeskShared.Models
{
    public class Ci
    {
        public int CIID { get; set; }
        public int CITYPEID { get; set; }
        public string? CINAME { get; set; }
        public string? DESCRIPTION { get; set; } 
        public string? LABEL { get; set; }
        public DateTime? CREATEDDATE { get; set; } 
        public DateTime? LASTMODIFIED { get; set; }
        public int? VERSION { get; set; }
        public int SITEID { get; set; }
        public int HELPDESKID { get; set; }
        public int? STATUSID { get; set; }
    }
}
 