﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Demo_Mvc5.Models.Handler
{
    public class ImageHandler:IHttpHandler
    {
        #region IHttpHandler Members

        public bool IsReusable
        {
            get { return true; }
        }

        public void ProcessRequest(HttpContext context)
        {
            // 如果UrlReferrer为空，则显示一张默认的禁止盗链的图片
            if (context.Request.UrlReferrer == null || context.Request.UrlReferrer.Host == null)
            {
                context.Response.ContentType = "image/JPEG";
                context.Response.WriteFile("/Content/Image/Forbidden.jpg");
            }
            else
            {
                // 如果 UrlReferrer中不包含自己站点主机域名，则显示一张默认的禁止盗链的图片
                if (context.Request.UrlReferrer.Host.Contains("localhost"))
                {
                    // 获取文件服务器端物理路径
                    string FileName = context.Server.MapPath(context.Request.FilePath);
                    context.Response.ContentType = "image/JPEG";
                    context.Response.WriteFile(FileName);
                }
                else
                {
                    context.Response.ContentType = "image/JPEG";
                    context.Response.WriteFile("/Content/Image/Forbidden.jpg");
                }
            }
        }

        #endregion
    }
}