using HelpDeskShared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDeskShared.Models
{
    public class SDUser
    {
        public int USERID { get; set; }
        public int EMPLOYEEID { get; set; }
        public string FIRSTNAME { get; set; }
        public string MIDDLENAME { get; set; }
        public string LASTNAME { get; set; }
        public string JOBTITLE { get; set; }
        public string STATUS { get; set; }
        public int REPORTINGTO { get; set; }
        public int DELETED_BY { get; set; }
        public DateTime DELETED_TIME { get; set; }
        public int TYPEID { get; set; } 
    }
}


 