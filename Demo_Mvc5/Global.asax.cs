using Demo_Mvc5.App_Start;
using Demo_Mvc5.Models.Ioc;
using Demo_Mvc5.Models.Log;
using log4net.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.IO;


namespace Demo_Mvc5
{
    public class MvcApplication : System.Web.HttpApplication
    {
        //private Logger logger = Logger.CreateLogger(typeof(MvcApplication));

        private static log4net.ILog logger = log4net.LogManager.GetLogger("MvcApplication");

        /// <summary>
        /// 网站启动时，第一次请求执行的，以后不执行（适合初始化）
        /// </summary>
        protected void Application_Start()
        {
            //配置log4
            XmlConfigurator.Configure(new FileInfo(Server.MapPath("~/Web.config")));

            AreaRegistration.RegisterAllAreas();//区域路由
            GlobalConfiguration.Configure(WebApiConfig.Register);//注册api路由
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);//注册filter

            RouteConfig.RegisterRoutes(RouteTable.Routes);//路由

            #region 拓展路由
            RouteConfig.RegisterMvcExtendRoutes(RouteTable.Routes);
            RouteConfig.RegisterExtendRoutes(RouteTable.Routes);
            #endregion


            BundleConfig.RegisterBundles(BundleTable.Bundles);

            #region Ioc写法
            ControllerBuilder.Current.SetControllerFactory(new UnityControllerFactoryNew());//替换默认的控制器工厂
            #endregion

        }


        protected void Application_End(object sender, EventArgs e)
        {
            //  在应用程序关闭时运行的代码
            logger.Info("Application_End");
        }

        /// <summary>
        /// 请求出现异常，都可以处理
        /// 也可以完成全局异常处理
        /// 
        /// filter只能处理控制器里面的异常
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Application_Error(object sender, EventArgs e)
        {
            // 在出现未处理的错误时运行的代码
            var error = Server.GetLastError();
            logger.Info("Application_Error");
            Response.ContentType = "text/html;charset=utf-8";
            Response.ContentEncoding = System.Text.Encoding.GetEncoding("utf-8"); //设置输出流为简体中文(解决乱码)
            Response.Write("出错");
            Server.ClearError();
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            // 在新会话启动时运行的代码
            Console.WriteLine("Session_Start 啥也不干");
            logger.Info("Session_Start");
        }
        protected void Session_End(object sender, EventArgs e)
        {
            // 在会话结束时运行的代码。 
            // 注意: 只有在 Web.config 文件中的 sessionstate 模式设置为
            // InProc(默认内存里) 时，才会引发 Session_End 事件。如果会话模式设置为 StateServer 
            // 或 SQLServer，则不会引发该事件。

            Console.WriteLine("Session_End 啥也不干");
            logger.Info("Session_End");
        }

        /// <summary>
        /// HttpModule注册名称_事件名称(类名称+“_”+事件名称)
        /// 约定的
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BaseModules_GlobalModuleEvent(object sender, EventArgs e)
        {
            //Response.Write("来自 Global.asax 的文字 GlobalModule_GlobalModuleEvent");
            logger.Info("GlobalModule_GlobalModuleEvent");
        }
    }
}
