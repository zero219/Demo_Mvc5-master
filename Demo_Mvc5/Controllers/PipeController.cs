using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Demo_Mvc5.Controllers
{
    public class PipeController : Controller
    {
        // GET: Pipe
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Handler()
        {
            IHttpHandler handler = base.HttpContext.Handler;
            ViewBag.HandlerName = handler.GetType().ToString();
            ViewBag.Url = Request.Url.AbsoluteUri;
            return View();
        }

        /// <summary>
        /// 拒绝浏览器
        /// </summary>
        /// <returns></returns>
        public ViewResult Refuse()
        {
            return View();
        }
    }
}