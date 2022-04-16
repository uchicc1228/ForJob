using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ForJob.Models
{
    public class AccInfoModel
    {
        public Guid QID { get; set; }

        public Guid ID { get; set; }
        public string UserName { get; set; }
        public string UserPhone { get; set; }
        public string UserEmail { get; set; }
        public string UsweAge { get; set; }

        public string[] CheckQuestion { get; set; }
        public string[] RadioQuestion { get; set; }
        public string[] TextQuestion { get; set; }


        public string[] CheckAnswer { get; set; }
        
        public string[] RadioAnswer { get; set; }

        public string[] TextAnswer { get; set; }

    }
}