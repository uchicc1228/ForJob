using ForJob.Managers;
using ForJob.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ForJob.Backstage

///這邊開始要製作使用者填寫之問卷
{
    public partial class UserQuestionary : System.Web.UI.Page
    {
        AccInfoModel info = new AccInfoModel();
        List<ListModel> list = new List<ListModel>(); 
        ListModel QuestionaryModel = new ListModel();
        ListManager _mgr = new ListManager();
        List<string> QQTEXT = new List<string>();
        List<string> QQRadio = new List<string>();
        List<string> QQCheck = new List<string>();
        int a;
        int b;
        int c;
        protected void Page_Load(object sender, EventArgs e)
        {


            string ID = Request.QueryString["ID"];

            //ListModel list = _mgr.GetAllQuestionOnUsweQuestion(Guid.Parse(ID));
            //this.rptQuestion.DataSource = list;
            //this.rptQuestion.DataBind();

            //用ID找出問卷本身資訊

            QuestionaryModel = _mgr.GetQuestionaryModel(Guid.Parse(ID));

            if (string.IsNullOrEmpty(QuestionaryModel.EndTime) == true)
            {
                QuestionaryModel.EndTime = "直到永遠";
            }
            this.lblTime.Text = "問卷持續時間：" + (QuestionaryModel.StartTime.ToString("yyyy/MM/dd")) + " ～ " + QuestionaryModel.EndTime;
            this.lbltitle.Text = "<h1>" + QuestionaryModel.Title + "</h1>";
            this.lblContent.Text = QuestionaryModel.Content;
            this.Session["Title"] = this.lbltitle.Text;
            this.Session["Content"] = this.lblContent.Text;


            //用ID找出問卷問題資訊

            list = _mgr.GetQuestionModel(Guid.Parse(ID));
            int listcount = list.Count;
            int i = 0;
            int k = 0;
            int j = 0;
            int RN = 0;
            foreach (var item in list)
            {
                if (item.QQMode == "單選")
                {
                    if (item.Answer.Contains(","))
                    {
                        
                        this.form1.Controls.Add(new Literal() { ID = "rdoltl" + i, Text = "<br/>" + item.Question + ":" });
                        QQRadio.Add(item.Question);
                        info.RadioQuestion = QQRadio;
                        string[] array = item.Answer.Split(',');
                        foreach (var item2 in array)
                        {
                           
                            this.form1.Controls.Add(new RadioButton() { ID = "rdo" + i, Text = item2 ,GroupName = "group" + RN });
                           
                             i++;
                             a++;
                        }
                        RN++;
                        continue;
                    }
                    else
                    {
                      
                        QQRadio.Add(item.Question);
                        info.RadioQuestion = QQRadio;
                        BuildRadioBox(i, item.Answer, item.Question);
                        a++;
                        i++;
                    }


                }
                if (item.QQMode == "複選")
                {
                    if (item.Answer.Contains(","))
                    {
                       
                        this.form1.Controls.Add(new Literal() { ID = "checkltl" + j, Text = "<br/>" + item.Question + ":" });
                        
                        string[] array = item.Answer.Split(',');
                        QQCheck.Add(item.Question);
                        info.CheckQuestion = QQCheck;
                        foreach (var item2 in array)
                        {
                           

                            this.form1.Controls.Add(new CheckBox() { ID = "chk" + j, Text = item2 });
                            b++;
                            j++;
                        }
                       
                        continue;
                    }
                    else
                    {
                     
                        QQCheck.Add(item.Question);
                        info.CheckQuestion = QQCheck;
                        BuildCheckBox(j, item.Answer, item.Question);
                        b++;
                        j++;
                    }

                }
                if (item.QQMode == "文字")
                {
                   
                    QQTEXT.Add(item.Question);
                    info.TextQuestion= QQTEXT;

                    BuildTextBox(k, item.Question);
                    k++;
                    c++;

                }

            }

        }

        private void BuildTextBox(int i, string Question)
        {

            this.form1.Controls.Add(new Literal() { ID = "textltl" + i, Text = "<br/>" + Question + ":" });
            this.form1.Controls.Add(new TextBox() { ID = "txt" + i });

        }
        private void BuildCheckBox(int j, string Answer, string Question)
        {

            this.form1.Controls.Add(new Literal() { ID = "checkltl" + j, Text = "<br/>" + Question + ":" + "<br/>" });
            this.form1.Controls.Add(new CheckBox() { ID = "chk" + j, Text = Answer });


        }
        private void BuildRadioBox(int k, string Answer, string Question)
        {

            //this.form1.Controls.Add(new Literal() { ID = "rdoltl" + k, Text = "<br/>" + Question + ":" + "<br/>" });
            this.form1.Controls.Add(new RadioButton() { ID = "rdo" + k, Text = Answer ,GroupName=$"group{k}"});


        }

        protected void btnback_Click(object sender, EventArgs e)
        {
            Response.Redirect("Index.aspx");
        }













        protected void btnyes_Click(object sender, EventArgs e)
        {
            //將TEXTBOX內容寫入
            if (this.FindControl("txt1") != null)
            {
                List<string> QQ = new List<string>();
                for (int x = 0; x < c; x++)
                {
                    TextBox Findtxt = (TextBox)this.FindControl($"txt{x}");
                    QQ.Add(Findtxt.Text);
                    this.info.TextAnswer = QQ;
                    //info.TextAnswer[x] = Findtxt.Text;
                }
            }
            else if (this.FindControl("txt0") != null)
            {
                TextBox Findtxt = (TextBox)this.FindControl("txt0");
                List<string> QQ = new List<string>();
                QQ.Add(Findtxt.Text);
                this.info.TextAnswer = QQ;
                //info.TextAnswer[0] = Findtxt.Text;
            }



            //將checkbox內容寫入
            if (this.FindControl("chk1") != null)
            {
                List<string> QQ = new List<string>();
                for (int x = 0; x < b; x++)
                {
                    CheckBox Findtxt = (CheckBox)this.FindControl($"chk{x}");
                    if (Findtxt.Checked)
                    {

                        QQ.Add(Findtxt.Text);
                        this.info.CheckAnswer = QQ;

                    }
                    else
                    {
                        QQ.Add("未選擇");
                        this.info.CheckAnswer = QQ;
                    }
                }
            }
            else if (this.FindControl("chk0") != null)
            {
                List<string> QQ = new List<string>();
                CheckBox Findtxt = (CheckBox)this.FindControl("chk0");
                if (Findtxt.Checked)
                {

                    QQ.Add(Findtxt.Text);
                    this.info.CheckAnswer = QQ;

                }
                else
                {
                    QQ.Add("未選擇");
                    this.info.CheckAnswer = QQ;
                }
            }



            //將radio內容寫入
            if (this.FindControl("rdo1") != null)
            {
                List<string> QQ = new List<string>();
                for (int x = 0; x < c; x++)
                {
                    RadioButton Findtxt = (RadioButton)this.FindControl($"rdo{x}");
                    if (Findtxt.Checked)
                    {
                        QQ.Add(Findtxt.Text);
                        this.info.RadioAnswer = QQ;


                    }
                    else
                    {
                        QQ.Add("未選擇");
                        this.info.CheckAnswer = QQ;
                    }
                }
            }
            else if (this.FindControl("rdo0") != null)
            {
                RadioButton Findtxt = (RadioButton)this.FindControl("rdo0");
                List<string> QQ = new List<string>();
                if (Findtxt.Checked)
                {
                    QQ.Add(Findtxt.Text);
                    this.info.RadioAnswer = QQ;
                }
                else
                {
                    QQ.Add("未選擇");
                    this.info.CheckAnswer = QQ;
                }
            }
            //將會員資料寫入 新Session
            //不用QUESTIONID
            this.Session["UserID"] = Guid.NewGuid();
            this.Session["UsweName"] = this.txtName.Text;
            this.Session["UserPhone"] = this.txtPhone.Text;
            this.Session["UserEmail"] = this.txtEmail.Text;
            this.Session["UserAge"] = this.txtAge.Text;
            //this.Session["QuestionID"] = QuestionModel.QuestionID;
            this.Session["ALLRdoQuestion"] = this.info.RadioQuestion;
            this.Session["ALLChkQuestion"] = this.info.CheckQuestion;
            this.Session["ALLTxtQuestion"] = this.info.TextQuestion;
            //for(int i = 0; i <info.RadioQuestion.Count; i++)
            //{
            //    if(info.RadioAnswer == null)
            //    {
            //        info.RadioAnswer.Add("未選擇");
            //    }
            //    if (info.RadioAnswer.Count  != info.RadioQuestion.Count)
            //    {
            //        info.RadioAnswer.Add("未選擇");
            //    }
            //}
          
            this.Session["ALLRdoAnswer"] = this.info.RadioAnswer;
            this.Session["ALLChkAnswer"] = this.info.CheckAnswer;
            this.Session["ALLTxtAnswer"] = this.info.TextAnswer;

            string url = "~/IfoConfirmPage.aspx?ID=" + Request.QueryString["ID"];
            Response.Redirect(url);





            //顯示出頁面所有ㄉsession
            for (int i = 0; i < Session.Count; i++)
            {
                var crntSession = Session.Keys[i];
                Response.Write(string.Concat(crntSession, "=", Session[crntSession]) + "<br />");
            }
        }
    }
}