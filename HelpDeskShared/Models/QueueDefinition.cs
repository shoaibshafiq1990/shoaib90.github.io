using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDeskShared.Models
{
    public class QueueDefinition
    {
        public int QUEUEID { get; set; }
        public string? QUEUENAME { get; set; }
        public string? QUEUEDESCRIPTION { get; set; }
        public int SITEID { get; set; }
        public string? SENDERNAME { get; set; }
        public string? REPLYADDRESS { get; set; }
        public int CIID { get; set; }
        public int ISDELETED { get; set; }
        public int HELPDESKID { get; set; }
    }
}


 
