using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ForJob.Models
{
    public class ListModel
    {
        public Guid ID { get; set; }
        public Guid QuestionID { get; set; }
        public int Number { get; set; }
        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime StartTime { get; set; }

        public string StartTime_string { get; set; }

        public string EndTime { get; set; }


        public string StatusList { get; set; }

        public string Question { get; set; }

        public string Answer { get; set; }

        public string QIsNecessary { get; set; }

        public string QQMode { get; set; }


        public string QuestionUrl { get; set; }
        public string QuestionEditUrl { get; set; }
        public string QCatrgory { get; set; }
    }

}