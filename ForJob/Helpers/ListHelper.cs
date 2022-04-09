using ForJob.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ForJob.Helpers
{
    public class ListHelper
    {

        public List<ListModel> PaginationList(List<ListModel> qq ,int pageIndex)
        {
            var pagesize = 2;
            int skip = pagesize * (pageIndex - 1);  // 計算跳頁數
            if (skip < 0)
                skip = 0;
            
            return qq.Skip(skip).Take(2).ToList();

        }
    }
}