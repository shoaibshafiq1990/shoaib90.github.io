using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDeskShared.Models
{
    public class DepartmentDefinition
    {
        public int DEPTID { get; set; }
        public string DEPTNAME { get; set; }
        public int DEPTHEADID { get; set; }
        public string PHONENO { get; set; }
        public int FAX { get; set; }
        public int SITEID { get; set; }
        public string DEPTDESC { get; set; }
        public int ISDELETED { get; set; }
    }
}


 