using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Demo_Mvc5.Models.RouteModel
{
    public class ExtendRoute : RouteBase
    {
        /// <summary>
        /// 解析路由信息
        /// </summary>
        /// <param name="httpContext"></param>
        /// <returns></returns>
        public override RouteData GetRouteData(HttpContextBase httpContext)
        {
            //拒绝谷歌浏览器
            if (httpContext.Request.UserAgent.IndexOf("Chrome/64.0.3325.181") >= 0)
            {
                RouteData rd = new RouteData(this, new MvcRouteHandler());
                rd.Values.Add("controller", "Pipe");
                rd.Values.Add("action", "Refuse");
                return rd;
            }
            return null;
        }

        /// <summary>
        /// 指定处理的虚拟路径
        /// </summary>
        /// <param name="requestContext"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public override VirtualPathData GetVirtualPath(RequestContext requestContext, RouteValueDictionary values)
        {
            return null;
        }
    }
}