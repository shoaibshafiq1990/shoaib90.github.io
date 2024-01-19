using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace HelpDeskShared.Models
{
    public class CategoryDefinition
    {
        public int CATEGORYID { get; set; }
        public string CATEGORYNAME { get; set; } 
        public string CATEGORYDESCRIPTION { get; set; }
        public int ISDELETED { get; set; }
        public int HELPDESKID { get; set; }
    }
}


 