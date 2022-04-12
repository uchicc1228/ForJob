using ForJob.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ForJob.API
{
    /// <summary>
    /// GetAllList 的摘要描述
    /// </summary>
    public class GetAllList : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            ListManager _mgr = new ListManager();
            //列出所有
            if (string.Compare("GET", context.Request.HttpMethod, true) == 0 && !string.IsNullOrEmpty(context.Request.QueryString["ALL"]))
            {
                var qq = context.Request.QueryString["ALL"];
                var list = _mgr.GetAllList();
                var listTop10 = list.Take(10).ToList();
                string jsonText = Newtonsoft.Json.JsonConvert.SerializeObject(listTop10);
                context.Response.ContentType = "application/json";
                context.Response.Write(jsonText);
                return;
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