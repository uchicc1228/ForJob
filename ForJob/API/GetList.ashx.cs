using ForJob.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ForJob.API
{
    /// <summary>
    /// GetList 的摘要描述
    /// </summary>
    public class GetList : IHttpHandler
    {
        ListManager _mgr = new ListManager();
        public void ProcessRequest(HttpContext context)
        {

            if (string.Compare("GET", context.Request.HttpMethod, true) == 0 )
            {
                if(!string.IsNullOrEmpty(context.Request.QueryString["Title"]))
                {
                    string time_start = context.Request.QueryString["time_start"];
                    string time_end = context.Request.QueryString["time_end"];
                    string title = context.Request.QueryString["Title"];


                    var model = _mgr.FindList(title, time_start, time_end);
                    string jsonText = Newtonsoft.Json.JsonConvert.SerializeObject(model);

                    context.Response.ContentType = "application/json";
                    context.Response.Write(jsonText);
                    return;
                }
                else 
                {
                    string time_start = context.Request.QueryString["time_start"];
                    string time_end = context.Request.QueryString["time_end"];
                    
                    var model = _mgr.FindListTime(time_start , time_end);
                    string jsonText = Newtonsoft.Json.JsonConvert.SerializeObject(model);
                    context.Response.ContentType = "application/json";
                    context.Response.Write(jsonText);
                    return;
                }

                
                
            }
            
            //列出所有
            //if (string.Compare("GET", context.Request.HttpMethod, true) == 0)
            //{
            //    var list = _mgr.GetAllList();
            //    string jsonText = Newtonsoft.Json.JsonConvert.SerializeObject(list);
                
            //    context.Response.ContentType = "application/json";
            //    context.Response.Write(jsonText);
            //    return;
            //}
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