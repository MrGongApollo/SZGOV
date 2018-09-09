using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace LayUI.RestierApi
{
    public class BasicAuthorizeAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            string empCode = HttpContext.Current.Session["User"] + "";
            try
            {
                if (string.IsNullOrEmpty(empCode))
                {
                }
            }
            catch (Exception ex)
            {
                //Log.WriteLogFile("劳防用品New.txt", "连接数据库异常", ex);
                //httpContext.Response.Redirect("~/LFNew/Error/Index");
               
            }
        }

        protected override void HandleUnauthorizedRequest(HttpActionContext actionContext)
        {
            actionContext.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized)
            {
                ReasonPhrase = "当前无权限访问该资源"
            };
        }
    }
}