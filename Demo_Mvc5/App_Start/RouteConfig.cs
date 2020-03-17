using Demo_Mvc5.Models.RouteModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Demo_Mvc5
{
    public class RouteConfig
    {
        
        /// <summary>
        /// 路由配置
        /// </summary>
        /// <param name="routes"></param>
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");//忽略路由
            routes.IgnoreRoute("Ignore/{*pathInfo}"); //Ignore文件夹下不按路由规则执行

            routes.MapRoute(
               name: "About",
               url: "about",
               defaults: new { controller = "First", action = "Str", id = UrlParameter.Optional }
               );//静态路由，注意顺序

            //正则路由
            routes.MapRoute(
              name: "Regex",
              url: "{controller}/{action}_{Year}_{Month}_{Day}",
             defaults: new { controller = "First", action = "Time", id = UrlParameter.Optional },
             constraints: new { Year = @"^\d{4}", Month = @"\d{2}", Day = @"\d{2}" }
              );



            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },//默认
                namespaces: new string[] { "Demo_Mvc5.Controllers" }//命名空间路由
            );


        }


        #region 拓展路由
        /// <summary>
        /// 拒绝谷歌浏览器
        /// </summary>
        /// <param name="routes"></param>
        public static void RegisterExtendRoutes(RouteCollection routes)
        {
            routes.Add(new ExtendRoute());
        }
        /// <summary>
        /// 定制
        /// </summary>
        /// <param name="routes"></param>
        public static void RegisterMvcExtendRoutes(RouteCollection routes)
        {
            routes.Add(new Route("zzc/{*Info}", new ZzcRouteHandler()));
        }

        #endregion

    }
}
