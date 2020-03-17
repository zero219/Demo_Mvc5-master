using Demo_Mvc5.Models.Extension;
using Demo_Mvc5.Models.Login;
using Demo_Mvc5.Models.VerifyCode;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Demo_Mvc5.Controllers
{
    public class FourthController : Controller
    {
        // GET: Fourth
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="name"></param>
        /// <param name="password"></param>
        /// <param name="verify"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Login(string name, string password, string verify)
        {
            HttpContextBase context = this.HttpContext;
            LoginResult result = UserManage.UserLogin(context, name, password, verify);
            if (result == LoginResult.Success)
            {
                if (this.HttpContext.Session["CurrentUrl"] == null)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    string url = this.HttpContext.Session["CurrentUrl"].ToString();
                    this.HttpContext.Session["CurrentUrl"] = null;
                    return Redirect(url);
                }
            }
            else
            {
                ModelState.AddModelError("failed", EnumExtension.GetRemark(result));
                return View();
            }
        }
        /// <summary>
        /// 验证码
        /// </summary>
        /// <returns></returns>
        public ActionResult VerifyCode()
        {
            string code = string.Empty;
            Bitmap bitmap = VerifyCodeHelper.CreateVerifyCode(out code);
            base.HttpContext.Session["CheckCode"] = code;
            MemoryStream stream = new MemoryStream();
            bitmap.Save(stream, ImageFormat.Gif);
            return File(stream.ToArray(), "image/gif");//返回FileContentResult图片
        }

        /// <summary>
        /// 退出
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Logout()
        {
            this.HttpContext.UserLogout();
            return RedirectToAction("Index", "Home"); ;
        }

        public ActionResult FilterErrorIndex()
        {
            throw new Exception("FilterErrorIndex Exception");
        }
    }
}