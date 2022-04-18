using ForJob.Managers;
using ForJob.Models;
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
        
        AccInfoModel info = new AccInfoModel();
        List<ListModel> list = new List<ListModel>();
        ListModel QuestionModel = new ListModel();
       
        ListManager _mgr = new ListManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            this.lblName.Text = this.Session["UsweName"] as string;
            info.UserName = this.lblName.Text;

            this.lblPhone.Text = this.Session["UserPhone"] as string;
            info.UserPhone = this.lblPhone.Text;


            this.lblEmail.Text = this.Session["UserEmail"] as string;
            info.UserEmail = this.lblEmail.Text;

            this.lblAge.Text = this.Session["UserAge"] as string;
            info.UsweAge = this.lblAge.Text;

            this.lblTtile.Text = this.Session["Title"] as string;
            info.QuestionTitle = this.lblTtile.Text;

            this.lblContent.Text = this.Session["Content"] as string;
            info.QuestionContent = this.lblContent.Text;

            List<string> list = new List<string>();
            /////我取到ㄌ我取到ㄌ我取到ㄌ我取到ㄌ我取到ㄌ我取到ㄌ我取到ㄌ我取到ㄌ我取到ㄌ我取到ㄌ我取到ㄌ我取到ㄌ我取到ㄌ我取到ㄌ我取到ㄌ我取到ㄌ
            List<string> ALLRdoQuestion = new List<string>();
            ALLRdoQuestion = (List<string>)this.Session["ALLRdoQuestion"];
            info.RadioQuestion = ALLRdoQuestion;


            List<string> ALLChkQuestion = new List<string>();
            ALLChkQuestion = (List<string>)this.Session["ALLChkQuestion"];
            info.CheckQuestion = ALLChkQuestion;


            List<string> ALLTxtQuestion = new List<string>();
            ALLTxtQuestion = (List<string>)this.Session["ALLTxtQuestion"];
            info.TextQuestion = ALLTxtQuestion;

            List<string> ALLRdoAnswer = new List<string>();
            ALLRdoAnswer = (List<string>)this.Session["ALLRdoAnswer"];
            info.RadioAnswer = ALLRdoAnswer;

            List<string> ALLChkAnswer = new List<string>();
            ALLChkAnswer = (List<string>)this.Session["ALLChkAnswer"];
            info.CheckAnswer = ALLChkAnswer;

            List<string> ALLTxtAnswer = new List<string>();
            ALLTxtAnswer = (List<string>)this.Session["ALLTxtAnswer"];
            info.TextAnswer = ALLTxtAnswer;
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ///

            for(int i = 0; i < ALLRdoQuestion.Count; i++)
            {
                this.ltlRdo.Text += "<br/>問題：" + ALLRdoQuestion[i];
                this.ltlRdo.Text += "\t所選答案：" + ALLTxtQuestion[i] + "<br/><br/>";
               
            };
            for (int i = 0; i < ALLChkQuestion.Count; i++)
            {
                this.ltlRdo.Text += "<br/>問題：" + ALLChkQuestion[i];
                this.ltlRdo.Text += "\t所選答案：" + ALLChkAnswer[i] + "<br/><br/>";
            };
            for (int i = 0; i < ALLTxtQuestion.Count; i++)
            {
                this.ltlRdo.Text += "<br/>問題：" + ALLTxtQuestion[i];
                this.ltlRdo.Text += "\t你ㄉ回答：" + ALLTxtAnswer[i] + "<br/><br/>";
            };
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //用名稱去找QuestionID,QID






        }

        protected void btncancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Backstage/Index.aspx");
        }

        protected void btnconfirm_Click(object sender, EventArgs e)
        {
           


            //寫入資料到USER資料表
        }
    }
}