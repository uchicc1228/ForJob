using ForJob.Managers;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;

namespace ForJob.API
{
    /// <summary>
    /// DeleteList 的摘要描述
    /// </summary>
    public class DeleteList : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {

            ListManager _mgr = new ListManager();
            NameValueCollection IDcol = new NameValueCollection();

            if (string.Compare("POST", context.Request.HttpMethod) == 0 &&
                string.Compare("DELETE", context.Request.QueryString["Action"], true) == 0)
            {
                List<string> list = new List<string>();
                //Load Form variables into NameValueCollection variable.
                IDcol = context.Request.Form;
                string ID = IDcol.ToString().Trim();  
                if (ID.Contains("&"))
                {
                    int i = 0;
                    foreach(string IDstr in ID.Split('&'))
                    {
                        string qq = IDstr.ToString();
                        string newqq =qq.Remove(0,9);
                        if(_mgr.GetOneList(Guid.Parse(newqq)) == null)
                        {
                            context.Response.ContentType = "text/plain";
                            context.Response.Write("NULL");
                            break;
                        }
                        else
                        {
                            if(_mgr.DeleteQuestionary(Guid.Parse(newqq)) == true)
                            {
                                context.Response.ContentType = "text/plain";
                                context.Response.Write("OK");

                            }              

                        }

                                           
                    }

                    return;
                }
                else
                {
                    if (string.IsNullOrEmpty(ID) != true)
                    {
                        string qq = ID.Remove(0, 9);
                        if (_mgr.GetOneList(Guid.Parse(qq)) == null)
                        {
                            context.Response.ContentType = "text/plain";
                            context.Response.Write("NULL");
                            return;
                        }
                        else
                        {
                            if (_mgr.DeleteQuestionary(Guid.Parse(qq)) == true)
                            {
                                context.Response.ContentType = "text/plain";
                                context.Response.Write("OK");
                                return;
                            }

                        }
                    }
                 
                }

              
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}