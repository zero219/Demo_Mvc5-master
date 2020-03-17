using Demo_Mvc5.Models.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Demo_Mvc5.Models.Filter
{
    /// <summary>
    /// 检验登陆权限的filter
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true)]
    public class AuthorityFilterAttribute : AuthorizeAttribute
    {
        /// <summary>
        /// 未登录时返回的地址
        /// </summary>
        private string _LoginPath = string.Empty;

        public AuthorityFilterAttribute()
        {
            this._LoginPath = "/Fourth/Login";
        }
        public AuthorityFilterAttribute(string loginPath)
        {
            this._LoginPath = loginPath;
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            //如果控制器或action方法带AllowAnonymous特性就不用检验
            if (filterContext.ActionDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true) || filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true))
            {
                return;
            }
            var sessionUser = HttpContext.Current.Session["CurrentUser"];
            //var memberValidation = HttpContext.Current.Request.Cookies.Get("CurrentUser");//使用cookie
            //也可以使用数据库、nosql等介质
            if (sessionUser == null || !(sessionUser is CurrentUser))
            {
                HttpContext.Current.Session["CurrentUrl"] = filterContext.RequestContext.HttpContext.Request.RawUrl;
                filterContext.Result = new RedirectResult(this._LoginPath);
            }
        }
    }
}