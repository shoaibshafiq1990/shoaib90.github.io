using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDeskShared
{
    public class User
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreationDate { get; set; }
        public int LastUpdateBy { get; set; }
        public DateTime? LastUpdateDate { get; set; }
    }
}
