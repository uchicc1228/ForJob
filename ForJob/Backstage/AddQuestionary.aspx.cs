using ForJob.Managers;
using ForJob.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ForJob.Backstage
{
    public partial class AddQuestionary : System.Web.UI.Page
    {
        int i;
        ListManager _mgr = new ListManager();
        ListModel model = new ListModel();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                this.plc1.Visible = true;
                this.plc2.Visible = false;

                string today = DateTime.Now.ToString("yyyy-MM-dd");
                this.txtTime_start.Value = today;
                this.checkcheck.Checked = true;
                this.btnconfirmQ.Visible = true;
                this.btnchanged.Visible = false;

            }

        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {

            //問卷資訊
            model.ID = Guid.Parse(Request.QueryString["ID"]);
            model.StartTime = Convert.ToDateTime(this.txtTime_start.Value);
            model.EndTime = this.txtTime_end.Value;
            model.Title = this.txtName.Text;
            model.Content = this.txtExplain.Text;


            if (this.checkcheck.Checked == false)
            {
                model.StatusList = "開啟";
            }
            else
            {
                model.StatusList = "關閉";
            }

            if (string.IsNullOrEmpty(model.EndTime) == false)
            {
                if (model.StartTime > Convert.ToDateTime(model.EndTime))
                {
                    Response.Write("<script>alert('開始日期不可大於結束日期！')</script>");
                    return;
                }
            }

            if (_mgr.GetAccount(model.Title) != null)
            {
                Response.Write("<script>alert('存在相同標題問卷！')</script>");
                return;
            }

            else
            {
                if (_mgr.CreateQuestionary(model) == false)
                {
                    Response.Write("<script>alert('問卷創建失敗！')</script>");
                }
                else
                {
                    Response.Write("<script>alert('創立成功！')</script>");
                    this.plc1.Visible = false;
                    this.plc2.Visible = true;
                    ListModel model2 = _mgr.GetAccount(model.Title);
                    this.lblName.Text = model2.Title;
                    this.lblContent.Text = model2.Content;
                    this.lblStartTime.Text = model2.StartTime.ToString("yyyy/MM/dd");
                    this.lblEndTime.Text = model2.EndTime;
                    this.Session["Question"] = "123";
                    this.Session["Number"] = 123;
                }
            }


        }
        protected void dowList_SelectedIndexChanged1(object sender, EventArgs e)
        {

        }

        protected void btnconfirmQ_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(this.dowList.SelectedValue) == 0)
            {
                Response.Write("這是自訂模式");
                model.ID = Guid.Parse(Request.QueryString["ID"]);
                ListModel model2 = _mgr.GetAccount(model.ID);
                model2.QCatrgory = "自訂";

                if(string.IsNullOrEmpty(this.txtQuestion.Text) != true)
                {
                    model2.Question = this.txtQuestion.Text;
                }
                else
                {
                    Response.Write("<script>alert('尚未輸入題目')</script>");
                    return;
                }
                    
                    

           



                if (this.checknecessary.Checked)
                {
                    //必填為0
                    model2.QIsNecessary = "必填";
                }
                else
                {   //非必填為1
                    model2.QIsNecessary = "非必填";
                }


                if (Convert.ToInt32(this.dowMode.SelectedValue) == 0)
                {
                    //單選為0
                    model2.QQMode = "單選";
                }
                else if (Convert.ToInt32(this.dowMode.SelectedValue) == 1)
                {
                    //複選為1
                    model2.QQMode = "複選";
                }
                else
                {
                    model2.QQMode = "文字";

                }

                if (string.IsNullOrEmpty(this.txtanswer.Text) != true & model2.QQMode !="文字")
                {
                    model2.Answer = this.txtanswer.Text; 
                }
                else if(model2.QQMode == "文字")
                {
                    model2.Answer = this.txtanswer.Text; 
                }

                else
                {
                    Response.Write("<script>alert('因回答類型非文字方塊,需輸入問題回答')</script>");
                    return;
                }


                if (_mgr.CreateQuestion(model2) == true)
                {


                    Response.Write("<script>alert('問題新增成功！')</script>");
                    
                    List<ListModel> list = _mgr.GetAllQuestion(model2.ID);
                    this.ret1.DataSource = list;
                    this.ret1.DataBind();
                }

                else
                {

                    Response.Write("<script>alert'問題新增失敗！ 可能是存在相同問題')</script>");
                    return;
                }



            }
            else if (Convert.ToInt32(this.dowList.SelectedValue) == 1)
            {
                Response.Write("這是常用模式");


            }
        }

        protected void dowMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(this.dowMode.SelectedValue) == 2)
            {
                this.txtanswer.Text = string.Empty;
                this.txtanswer.Enabled = false;
            }
            else
            {
                this.txtanswer.Enabled = true;
            }
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            //抓出我要ㄉ資訊1.種類(自訂問題或是常用問題) 2.問題 3.回答 4.單選複選文字 5.必填 帶入到上面的輸入框

            //ListModel model2 = new ListModel();
            //model2.ID = Guid.Parse(Request.QueryString["ID"]);       
            //model2 = _mgr.GetAllQuestionInfo(model2);
            //if(model2.QCatrgory == "自訂")
            //{
            //    this.dowList.SelectedIndex = 0;
            //}
            //else
            //{
            //    this.dowList.SelectedIndex = 1;
            //}

            //this.txtQuestion.Text = model2.Question;
            //this.txtanswer.Text= model2.Answer;

            //if(model2.QQMode == "複選")
            //  this.dowMode.SelectedIndex = 1;
            //if (model2.QQMode == "單選")
            //    this.dowMode.SelectedIndex = 0;
            //if (model2.QQMode == "文字")
            //    this.dowMode.SelectedIndex = 2;
            //if(model.QIsNecessary =="必填")
            //     this.checkcheck.Checked = true;

            //else
            //     this.checkcheck.Checked = false;

            //this.btnconfirmQ.Visible = false;
            //this.btnchanged.Visible = true;

        }

        protected void btnchanged_Click(object sender, EventArgs e)
        {
            model.ID = Guid.Parse(Request.QueryString["ID"]);
            ListModel model2 = _mgr.GetAllQuestionInfo(model.ID);
            this.Session["Question"] = this.txtQuestion.Text;
            this.Session["Answer"] = this.txtanswer.Text;

            if (Convert.ToInt32(this.dowList.SelectedValue) == 0)
            {
                this.Session["Catrgory"] = "自訂";
            }
            else
            {
                this.Session["Catrgory"] = "常用";
            }


            if (this.checknecessary.Checked)
            {
                //必填為0
                this.Session["IsNecessary"] = "必填";
            }
            else
            {   //非必填為1
                this.Session["IsNecessary"] = "非必填";
            }


            if (Convert.ToInt32(this.dowMode.SelectedValue) == 0)
            {
                //單選為0
                this.Session["Mode"] = "單選";
            }
            else if (Convert.ToInt32(this.dowMode.SelectedValue) == 1)
            {
                //複選為1
                this.Session["Mode"] = "複選";
            }
            else
            {
                this.Session["Mode"] = "文字";

            }

            this.lblmsg.Text = "請按送出以變更題目設定";

        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {






        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            if(this.Session["Question"].ToString() == "123")
            {
                Response.Write("<Script>alert('這顆按鈕是編輯資料時使用,如要新增問題請按加入')</Script>");
                return;
            }
            if (this.Session["Number"].ToString() == "123")
            {
                Response.Write("<Script>alert('這顆按鈕是編輯資料時使用,如要新增問題請按加入')</Script>");
                return;
            }

            model.ID = Guid.Parse(Request.QueryString["ID"]);
                model.Question = this.Session["Question"] as string;
                model.Answer = this.Session["Answer"] as string;
                model.QCatrgory = this.Session["Catrgory"] as string;
                model.QIsNecessary = this.Session["IsNecessary"] as string;
                model.QQMode = this.Session["Mode"] as string;
                model.ID = Guid.Parse(Request.QueryString["ID"]);
                model.Number = (int)this.Session["Number"];
            
                

            if (Session["Question"] as string != null)
            {
                if (_mgr.UpdateQuestion(model) == true)
                {
                    this.Session.RemoveAll();
                    this.lblmsg.Text = "";
                    this.txtanswer.Text = "";
                    this.txtQuestion.Text = "";
                    Response.Write("<script>alert('編輯成功')</script>");

                    List<ListModel> list = _mgr.GetAllQuestion(model.ID);
                    this.ret1.DataSource = list;
                    this.ret1.DataBind();

                }
            }
            else
            {
                Response.Write("<script>alert('請先按確認編輯按鈕')</script>");
            }

        }

        protected void ret1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "btnEdit":
                    ListModel model2 = new ListModel();
                    string[] arr = e.CommandArgument.ToString().Split(',');
                    Guid id;
                    Guid.TryParse(arr[0], out id);
                    int number;
                    int.TryParse(arr[1], out number);

                    model2.ID = id;
                    model2.Number = number;
                    this.Session["Number"] = model2.Number;
                    model2 = _mgr.GetAllQuestionInfo(model2);
                    if (model2.QCatrgory == "自訂")
                    {
                        this.dowList.SelectedIndex = 0;
                    }
                    else
                    {
                        this.dowList.SelectedIndex = 1;
                    }

                    this.txtQuestion.Text = model2.Question;
                    this.txtanswer.Text = model2.Answer;

                    if (model2.QQMode == "複選")
                        this.dowMode.SelectedIndex = 1;
                    if (model2.QQMode == "單選")
                        this.dowMode.SelectedIndex = 0;
                    if (model2.QQMode == "文字")
                        this.dowMode.SelectedIndex = 2;
                    if (model.QIsNecessary == "必填")
                        this.checkcheck.Checked = true;

                    else
                        this.checkcheck.Checked = false;

                    this.btnconfirmQ.Visible = false;
                    this.btnchanged.Visible = true;
                    break;

                case "btnDelete":
                    ListModel model3 = new ListModel();
                    string[] arr1 = e.CommandArgument.ToString().Split(',');
                    Guid id1;
                    Guid.TryParse(arr1[0], out id1);
                    Guid qid;
                    Guid.TryParse(arr1[1], out qid);
                    model3.ID = id1;
                    model3.QuestionID = qid;

                    if (_mgr.DeleteQuestion(model3) == true)
                    {
                        Response.Write("<script>alert('刪除成功')</script>");


                    }
                    List<ListModel> list = _mgr.GetAllQuestion(model3.ID);
                    this.ret1.DataSource = list;
                    this.ret1.DataBind();

                    break;
                default:
                    break;

            }






        }



        protected void ret1_ItemDataBound1(object sender, RepeaterItemEventArgs e)
        {





        }
    }
}