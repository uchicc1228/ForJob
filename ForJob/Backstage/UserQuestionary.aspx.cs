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
        List<ListModel> list = new List<ListModel>();
        ListModel QuestionModel = new ListModel();
        ListModel QuestionaryModel = new ListModel();
        ListManager _mgr = new ListManager();
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
            this.lbltitle.Text =　"<h1>" + QuestionaryModel.Title + "</h1>";
            this.lblContent.Text = QuestionaryModel.Content;


            //用ID找出問卷問題資訊
           
            list = _mgr.GetQuestionModel(Guid.Parse(ID));
            int listcount = list.Count;
            int i = 0;
            int k = 0;
            foreach (var item in list)
            {              
                if (item.QQMode == "單選")
                {
                    if (item.Answer.Contains(","))
                    {
                        this.form1.Controls.Add(new Literal() { ID = "ltl" + i, Text = "<br/>" + item.Question + ":" });
                        string[] array = item.Answer.Split(',');
                        foreach(var item2 in array)
                        {
                          
                            this.form1.Controls.Add(new RadioButton() { ID = "check" + i, Text = item2 });
                        }
                        continue;
                    }
                    else
                    {
                        BuildRadioBox(i, item.Answer, item.Question);
                    }

                    
                }
                if(item.QQMode == "複選")
                {
                    if (item.Answer.Contains(","))
                    {
                        this.form1.Controls.Add(new Literal() { ID = "ltl" + i, Text = "<br/>" + item.Question + ":" });
                        string[] array = item.Answer.Split(',');

                        foreach (var item2 in array)
                        {
                            
                            this.form1.Controls.Add(new CheckBox() { ID = "check" + i, Text = item2 });
                        }
                        continue;
                    }
                    else
                    {
                        BuildCheckBox(i, item.Answer, item.Question);
                    }
                   
                }
                if(item.QQMode == "文字")
                {
                    if (item.Answer.Contains(","))
                    {
                        this.form1.Controls.Add(new Literal() { ID = "ltl" + i, Text = "<br/>" + item.Question + ":" });
                        string[] array = item.Answer.Split(',');

                        foreach (var item2 in array)
                        {
                            BuildTextBox(i, item2, item.Question);
                        }
                        continue;
                    }
                    else
                    {
                        BuildTextBox(i, item.Answer, item.Question);
                    }
                   
                }
                i++;
            }








        }

        private void BuildTextBox(int i,string Answer, string Question)
        {
           
            this.form1.Controls.Add(new Literal() { ID = "ltl" + i, Text = "<br/>" + Question + ":"});
            this.form1.Controls.Add(new TextBox() { ID = "txt" + i });

        }

        

        private void BuildCheckBox(int i,string Answer, string Question)
        {
          
            this.form1.Controls.Add(new Literal() { ID = "ltl" + i, Text = "<br/>" + Question + ":" + "<br/>" });
            this.form1.Controls.Add(new CheckBox() { ID = "check" + i , Text= Answer });


        }

        private void BuildRadioBox(int i,string Answer, string Question)
        {
            
            this.form1.Controls.Add(new Literal() { ID = "ltl" + i, Text = "<br/>" + Question + ":" + "<br/>" });
            this.form1.Controls.Add(new RadioButton() { ID = "rdo" + i, Text = Answer });


        }

        protected void btnback_Click(object sender, EventArgs e)
        {
            Response.Redirect("Index.aspx");
        }

        protected void btnyes_Click(object sender, EventArgs e)
        {
           
        }
    }
}