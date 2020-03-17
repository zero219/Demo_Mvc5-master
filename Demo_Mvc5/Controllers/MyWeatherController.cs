using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Demo_Mvc5.Weather;

namespace Demo_Mvc5.Controllers
{
    public class MyWeatherController : Controller
    {
        // GET: MyWeather
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string city)
        {
            WeatherWebService client = new WeatherWebService();
            var s = client.getWeatherbyCityName(city);
            if (s[8] == "")
            {
                ViewBag.Msg = "暂不支持你查询的城市";
            }
            else
            {
                ViewBag.ImgUrl = @"/Content/weather/" + s[8];
                ViewBag.General = s[1] + " " + s[6];
                ViewBag.Actually = s[10];
            }

            return View();
        }
    }
}