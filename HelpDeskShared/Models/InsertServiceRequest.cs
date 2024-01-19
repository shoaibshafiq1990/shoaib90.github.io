using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDeskShared.Models
{
    public class InsertServiceRequest
    {
        //for WorkOrder table
        public int WORKORDERID { get; set; }
        public int REQUESTERID { get; set; }
        public int CREATEDBYID { get; set; }
        //public int CREATEDTIME { get; set; }
        //public int DUEBYTIME { get; set; }
        public string TITLE { get; set; }
        public string description { get; set; }
        //public int MODEID { get; set; }
        public int DEPTID { get; set; }
        public int SITEID { get; set; }
        //public int ISPARENT { get; set; }
        //public int TEMPLATEID { get; set; }
        //public int serviceid { get; set; }
        //public int IS_CATALOG_TEMPLATE { get; set; }
        //public int FR_DUETIME { get; set; }
        //public int HELPDESKID { get; set;}

        //for WorkOrderStates table
        public int CATEGORYID { get; set; }
        public int SUBCATEGORYID { get; set; }
        //public int STATUSID { get; set; }
        public int PRIORITYID { get; set; }
        //public int OLA_STATUS { get; set; }
        public int HASATTACHMENT { get; set; }
        public int OWNERID { get; set; }
       // public int ASSIGNEDTIME { get; set; }

        //for WorkOrder_Queue Table
        public int QUEUEID { get; set; } 
    }
}
