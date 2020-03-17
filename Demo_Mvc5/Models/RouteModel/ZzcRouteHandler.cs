using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace Demo_Mvc5.Models.RouteModel
{
    public class ZzcRouteHandler : IRouteHandler
    {
        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            return new ZzcHandler(requestContext);
        }
    }
}