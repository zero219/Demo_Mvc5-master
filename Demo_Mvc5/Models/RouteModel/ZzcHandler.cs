using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace Demo_Mvc5.Models.RouteModel
{
    public class ZzcHandler:IHttpHandler
    {
        public ZzcHandler(RequestContext requestContext)
        {
            Console.WriteLine("构造ZzcHandler");
        }

        public void ProcessRequest(HttpContext context)
        {
            string url = context.Request.Url.AbsoluteUri;
            context.Response.Write(string.Format("这里是Zzc定制：{0}", this.GetType().Name));
            context.Response.Write((string.Format("当前地址为：{0}", url)));

            context.Response.End();
        }

        public virtual bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}