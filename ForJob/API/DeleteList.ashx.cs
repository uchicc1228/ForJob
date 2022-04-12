using ForJob.Managers;
using System;
using System.Collections.Generic;
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

            if (string.Compare("POST", context.Request.HttpMethod) == 0 &&
                string.Compare("DELETE", context.Request.QueryString["Action"], true) == 0)

            {
                Guid id = Guid.Parse(context.Request.Form["ID"]);

                // 加入 NULL 檢查
                var dbModel = _mgr.GetOneList(id);

                if (dbModel == null)
                {
                    context.Response.ContentType = "text/plain";
                    context.Response.Write("NULL");
                }
                else
                {
                    _mgr.DeleteList(id);
                    context.Response.ContentType = "text/plain";
                    context.Response.Write("OK");
                }
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