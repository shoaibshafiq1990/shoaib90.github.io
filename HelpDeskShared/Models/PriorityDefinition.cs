using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDeskShared.Models
{
    public class PriorityDefinition
    {
        public int PRIORITYID { get; set; }
        public string PRIORITYNAME { get; set; }
        public string PRIORITYCOLOR { get; set; }
        public int PRIORITYORDER { get; set; }
        public string PRIORITYDESCRIPTION { get; set; }
        public int ISDELETED { get; set; } 
        public int HELPDESKID { get; set; }
    }
}


 