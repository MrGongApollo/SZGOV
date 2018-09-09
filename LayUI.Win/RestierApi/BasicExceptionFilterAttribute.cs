using System;
using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;

namespace LayUI.RestierApi
{
    public class BasicExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            if (context.Exception is NotImplementedException)
            {
                string _errMsg = context.Exception == null ? "系统异常" : (context.Exception.InnerException != null
                    ? context.Exception.InnerException.Message : context.Exception.Message);
                context.Response = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent(_errMsg)
                };
            }
        }
    }
}