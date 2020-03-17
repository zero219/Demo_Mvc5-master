using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Demo_Mvc5.Models.Login
{
    /// <summary>
    /// 登录返回的结果
    /// </summary>
    public enum LoginResult
    {
        /// <summary>
        /// 登录成功
        /// </summary>
        [RemarkAttribute("登录成功")]
        Success = 0,
        /// <summary>
        /// 用户不存在
        /// </summary>
        [RemarkAttribute("用户不存在")]
        NoUser = 1,
        /// <summary>
        /// 密码错误
        /// </summary>
        [RemarkAttribute("密码错误")]
        WrongPwd = 2,
        /// <summary>
        /// 验证码错误
        /// </summary>
        [RemarkAttribute("验证码错误")]
        WrongVerify = 3,
        /// <summary>
        /// 账号被冻结
        /// </summary>
        [RemarkAttribute("账号被冻结")]
        Frozen = 4
    }
}