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
            if (string.Compare("GET", context.Request.HttpMethod, true) == 0)
            {
                var list = _mgr.GetAllList();
                string jsonText = Newtonsoft.Json.JsonConvert.SerializeObject(list);

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