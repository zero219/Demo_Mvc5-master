using Demo_Mvc5.Models.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Demo_Mvc5.Controllers
{
    public class FirstController : Controller
    {
        // GET: First
        [OutputCache(Duration = 5, VaryByParam = "none")]
        public ActionResult Index()
        {
            ViewBag.Now = DateTime.Now.ToString();
            Response.Cache.SetOmitVaryStar(true);//解决一个隐蔽bug
            return View();
        }

        public string Str()
        {
            return "123";
        }


        public string GetID(int? id)//"?"表示可以为空
        {
            return id.ToString();
        }

        public string Para(int other)
        {
            return other.ToString();
        }

        public string Parameters(string name, string remake)
        {
            return $"{name}-{remake}";
        }

        public string Time(int Year, int Month, int Day)
        {
            return string.Format("{0}年{1}月{2}日", Year, Month, Day);
        }
        /// <summary>
        /// 传值
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Data(int? id)
        {
            base.ViewData["User1"] = new CurrentUser()
            {
                Id = 7,
                Name = "Y",
                Account = " ╰つ Ｈ ♥. 花心胡萝卜",
                Email = "莲花未开时",
                Password = "落单的候鸟",
                LoginTime = DateTime.Now
            };

            base.ViewData["Something"] = 12345;

            base.ViewBag.Something = 23456;
            base.ViewBag.Name = "Eleven";
            base.ViewBag.Description = "Teacher";//js
            base.ViewBag.User = new CurrentUser()
            {
                Id = 7,
                Name = "IOC",
                Account = "限量版",
                Email = "莲花未开时",
                Password = "落单的候鸟",
                LoginTime = DateTime.Now
            };

            base.TempData["User"] = new CurrentUser()
            {
                Id = 7,
                Name = "CSS",
                Account = "季雨林",
                Email = "KOKE",
                Password = "落单的候鸟",
                LoginTime = DateTime.Now
            };//后台可以跨action  基于session

            if (id == null)
            {
                return this.RedirectToAction("TempDataPage");
            }
            else if (id == 1)
            {
                return View();
            }
            else if (id == 2)
            {
                return View(new CurrentUser()
                {
                    Id = 7,
                    Name = "一点半",
                    Account = "季雨林",
                    Email = "KOKE",
                    Password = "落单的候鸟",
                    LoginTime = DateTime.Now
                });
            }
            else
            {
                return View("~/Views/First/Data2.cshtml", new CurrentUser()
                {
                    Id = 7,
                    Name = "一点半",
                    Account = "季雨林",
                    Email = "KOKE",
                    Password = "落单的候鸟",
                    LoginTime = DateTime.Now
                });
            }
        }

        public ActionResult TempDataPage()
        {
            base.ViewBag.User = base.TempData["User"];//用一次就没了
            return View();
        }
    }
}