using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDeskShared.Models
{
    public class SubCategoryDefinition
    {
        public int SUBCATEGORYID { get; set; }
        public int CATEGORYID { get; set; }
        public string NAME { get; set; }
        public string DESCRIPTION { get; set; }
        public int ISDELETED { get; set; }
    }
}



 