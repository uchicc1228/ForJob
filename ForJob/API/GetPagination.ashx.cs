using ForJob.Helpers;
using ForJob.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ForJob.API
{
    /// <summary>
    /// GetPagination 的摘要描述
    /// </summary>
    public class GetPagination : IHttpHandler
    {
        ListManager _mgr = new ListManager();
        ListHelper _helper = new ListHelper();
        private const int _pageSize = 10;

        public void ProcessRequest(HttpContext context)
        {
            if (string.Compare("GET", context.Request.HttpMethod, true) == 0)
            {
                if (!string.IsNullOrEmpty(context.Request.QueryString["Title"]))
                {
                    string Title = context.Request.QueryString["Title"];
                    string time_start = context.Request.QueryString["time_start"];
                    string time_end = context.Request.QueryString["time_end"];
                    string pageIndexText = context.Request.QueryString["Index"];
                    int pageIndex =
                        (string.IsNullOrWhiteSpace(pageIndexText))
                            ? 1
                            : Convert.ToInt32(pageIndexText);

                    //有標題ㄉ查詢
                    var model = _mgr.PafinationHasTitle(Title ,time_start, time_end, _pageSize, pageIndex);

                    string jsonText = Newtonsoft.Json.JsonConvert.SerializeObject(model);
                    context.Response.ContentType = "application/json";
                    context.Response.Write(jsonText);
                    return;



                }
                else
                {
                    string time_start = context.Request.QueryString["time_start"];
                    string time_end = context.Request.QueryString["time_end"];
                    string pageIndexText = context.Request.QueryString["Index"];

                    int pageIndex =
                        (string.IsNullOrWhiteSpace(pageIndexText))
                            ? 1
                            : Convert.ToInt32(pageIndexText);

                    //無標題ㄉ查詢
                    var model = _mgr.Pafination(time_start, time_end, _pageSize, pageIndex);
                   
                    string jsonText = Newtonsoft.Json.JsonConvert.SerializeObject(model);
                    context.Response.ContentType = "application/json";
                    context.Response.Write(jsonText);
                    return;
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