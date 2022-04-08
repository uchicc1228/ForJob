using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ForJob.Models
{
    public class ListModel
    {
        public Guid ID { get; set; }
        public int Number { get; set; }
        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime StartTime { get; set; }

        public string StartTime_string { get; set; }

        public string EndTime { get; set; }

        
        public string StatusList { get; set; }

    


    }
}