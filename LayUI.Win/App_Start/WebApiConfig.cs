using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

using LayUI.RestierApi;
using System.Web.OData;
using System.Web.OData.Extensions;
using Microsoft.Restier.Publishers.OData;
using Microsoft.Restier.Publishers.OData.Batch;
using System.Web.Http.Cors;
using LayUI.Win.Help;

namespace LayUI.Win
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            RegisterModel(config, GlobalConfiguration.DefaultServer);

            //config.MapHttpAttributeRoutes();

            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);
        }

        public static async void RegisterModel(HttpConfiguration config
            , HttpServer server)
        {
            //注册异常捕获处理过程
            config.Filters.Add(new BasicExceptionFilterAttribute());
            //注册基本授权访问
            //config.Filters.Add(new BasicAuthorizeAttribute());

            // enable query options for all properties
            config.Filter().Expand().Select().OrderBy().MaxTop(null).Count();
            //config.SetTimeZoneInfo(TimeZoneInfo.Utc);
            await config.MapRestierRoute<RestierFilterApi>("odataApi", "odata", new RestierBatchHandler(server));

            //config.MessageHandlers.Add(new ETagMessageHandler());
        }

        /// <summary>
        /// 允许跨域调用
        /// </summary>
        /// <param name="config"></param>
        private static void EnableCrossSiteRequests(HttpConfiguration config)
        {
            //对所有的请求来源没有任何限制
            var cors = new EnableCorsAttribute(
             origins: "*",
             headers: "*",
             methods: "*"
             );
            config.EnableCors(cors);
        }

    }
}