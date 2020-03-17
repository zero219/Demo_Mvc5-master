using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Demo_Mvc5.Models.Login
{
    public class RemarkAttribute : Attribute
    {
        private string _remark = string.Empty;
        public RemarkAttribute(string remark)
        {
            _remark = remark;
        }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark
        {
            get
            {
                return _remark;
            }
            set
            {
                _remark = value;
            }
        }

        public string Description
        { get; set; }
    }
}