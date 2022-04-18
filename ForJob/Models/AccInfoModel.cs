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

        public List<string> CheckQuestion { get; set; }
        public List<string> RadioQuestion { get; set; }
        public List<string> TextQuestion { get; set; }

        public List<string> CheckAnswer { get; set; }

        public List<string> RadioAnswer { get; set; }
        public List<string> TextAnswer { get; set; }

        public string QuestionTitle { get; set; }
        public string QuestionContent { get; set; }



    }
}