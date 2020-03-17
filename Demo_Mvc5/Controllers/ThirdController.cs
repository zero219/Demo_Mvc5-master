using Demo_Mvc5.Models.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Demo_Mvc5.Controllers
{
    [AuthorityFilter]
    public class ThirdController : Controller
    {
        // GET: Third
        [AllowAnonymous]//不用检验
        public ActionResult Index()
        {
            return View();
        }

    }
}