using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LayUI.Data;

namespace LayUI.Win.Help
{
    public class LoginCheckedAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            try
            {
                string empCode = HttpContext.Current.Session["User"] + "";
                return true;
                if(string.IsNullOrEmpty(empCode)) 
                {
                    httpContext.Response.Redirect("~/Home/Login");
                    return false;
                }
            }
            catch (Exception ex)
            {
                //Log.WriteLogFile("劳防用品New.txt", "连接数据库异常", ex);
                //httpContext.Response.Redirect("~/LFNew/Error/Index");
                return false;
            }
            return true;
        }
    }
}