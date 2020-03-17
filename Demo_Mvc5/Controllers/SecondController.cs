using Bussiness.EFModel.EFFirstDB;
using Bussiness.Interface;
using Demo_Mvc5.App_Start;
using Remote.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Demo_Mvc5.Controllers
{
    public class SecondController : Controller
    {
        private ICategoryCommodityService _iCategoryCommodityService = null;
        public SecondController(ICategoryCommodityService iCategoryCommodityService)
        {
            this._iCategoryCommodityService = iCategoryCommodityService;
        }
        public SecondController() { }
        // GET: Second
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult RazorShow()
        {
            return View();
        }

        public ActionResult Render()
        {
            ViewBag.Name = "张三";
            return View();
        }

        public ActionResult DB()
        {

            User commodity = this._iCategoryCommodityService.Find<User>(2);
            return View();
        }

        public string MyWcf()
        {
            string str = string.Empty;
            using (HelloService service = new HelloService())
            {
                //利用代理调用方法
                str = service.Say("张三");
            }
            return str;
        }
    }
}