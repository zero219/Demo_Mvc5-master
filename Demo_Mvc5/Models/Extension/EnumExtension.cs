using Demo_Mvc5.Models.Log;
using Demo_Mvc5.Models.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Demo_Mvc5.Models.Extension
{
    public static class EnumExtension
    {
        //private static Logger logger = Logger.CreateLogger(typeof(EnumExtension));
        private static log4net.ILog logger = log4net.LogManager.GetLogger("EnumExtension");
        /// <summary>
        /// 获取当前枚举值的Remark
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string GetRemark(this Enum value)
        {
            string remark = string.Empty;
            Type type = value.GetType();
            FieldInfo fieldInfo = type.GetField(value.ToString());

            try
            {
                object[] attrs = fieldInfo.GetCustomAttributes(typeof(RemarkAttribute), false);
                RemarkAttribute attr = (RemarkAttribute)attrs.FirstOrDefault(a => a is RemarkAttribute);
                if (attr == null)
                {
                    remark = fieldInfo.Name;
                }
                else
                {
                    remark = attr.Remark;
                }
            }
            catch (Exception ex)
            {
                logger.Error("EnumExtension的GetRemark出现异常", ex);
            }

            return remark;
        }

        /// <summary>
        /// 获取当前枚举的全部Remark
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static List<KeyValuePair<string, string>> GetAllRemarks(this Enum value)
        {
            Type type = value.GetType();
            List<KeyValuePair<string, string>> result = new List<KeyValuePair<string, string>>();
            //ShowAttribute.
            foreach (var field in type.GetFields())
            {
                if (field.FieldType.IsEnum)
                {
                    object tmp = field.GetValue(value);
                    Enum enumValue = (Enum)tmp;
                    int intValue = (int)tmp;
                    result.Add(new KeyValuePair<string, string>(intValue.ToString(), enumValue.GetRemark()));
                }
            }
            return result;
        }
    }
}