using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ForJob.Backstage
{
    public partial class AdminPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //想要做Time_end +1  
            string Time = DateTime.Now.ToString("yyyy-MM-dd");          
            this.txtCalender_start.Value = "2018-01-01";
            this.txtCalender_end.Value = "2022-12-31";

        }

        protected void btnAddList_Click(object sender, EventArgs e)
        {
            Guid ID = Guid.NewGuid();
            Response.Redirect("AddQuestionary.aspx?ID=" + ID.ToString());
           
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            var List =Request.Form["hfID"].ToString();
            string[] arr = List.Split(',');


        }
    }
}