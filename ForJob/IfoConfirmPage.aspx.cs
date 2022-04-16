using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ForJob
{
    public partial class IfoConfirmPage : System.Web.UI.Page
    {
        Dictionary<string, string> MyDic = new Dictionary<string, string>();
        protected void Page_Load(object sender, EventArgs e)
        {
            this.lblName.Text = this.Session["UsweName"] as string;
            this.lblPhone.Text = this.Session["UserPhone"] as string;
            this.lblEmail.Text = this.Session["UserEmail"] as string;
            this.lblAge.Text = this.Session["UserAge"] as string;
            this.lblTtile.Text = this.Session["Title"] as string;
            this.lblContent.Text = this.Session["Content"] as string;

            string a =Session.Keys[0];
            string b = Session.Keys[1];
            string c = Session.Keys[2];
            string d = Session.Keys[3];
            string f = Session.Keys[4];
            string g = Session.Keys[5];
            string h = Session.Keys[6];
            string i = Session.Keys[1];

        }
    }
}