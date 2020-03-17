using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Demo_Mvc5.Models.Modules
{
    public class BaseModules : IHttpModule
    {
        public event EventHandler GlobalModuleEvent;

        public void Init(HttpApplication httpApplication)
        {
            httpApplication.BeginRequest += new EventHandler(context_BeginRequest);//Asp.net处理的第一个事件，表示处理的开始
            httpApplication.EndRequest += new EventHandler(context_EndRequest);//本次请求处理完成
        }

        // 处理BeginRequest 事件的实际代码
        void context_BeginRequest(object sender, EventArgs e)
        {
            HttpApplication application = (HttpApplication)sender;
            HttpContext context = application.Context;
            string extension = Path.GetExtension(context.Request.Url.AbsoluteUri);
            if (string.IsNullOrWhiteSpace(extension) && !context.Request.Url.AbsolutePath.Contains("Verify"))
                context.Response.Write(string.Format("<h1>来自GlobalModule 的处理，{0}请求到达</h1>", DateTime.Now.ToString()));

            //处理地址重写
            if (context.Request.Url.AbsolutePath.Equals("/Pipe/Some", StringComparison.OrdinalIgnoreCase))
                context.RewritePath("/Pipe/Handler");

            //调用Global中的GlobalModule_GlobalModuleEvent事件
            if (GlobalModuleEvent != null)
                GlobalModuleEvent.Invoke(this, e);
        }

        // 处理EndRequest 事件的实际代码
        void context_EndRequest(object sender, EventArgs e)
        {
            HttpApplication application = (HttpApplication)sender;
            HttpContext context = application.Context;
            string extension = Path.GetExtension(context.Request.Url.AbsoluteUri);
            if (string.IsNullOrWhiteSpace(extension) && !context.Request.Url.AbsolutePath.Contains("Verify"))
                context.Response.Write(string.Format("<h1 style='color:#f00'>来自GlobalModule的处理，{0}请求结束</h1>", DateTime.Now.ToString()));
        }
        public void Dispose()
        {
            //throw new NotImplementedException();
        }
    }
}