using Demo_Mvc5.Models.Filter;
using System.Web;
using System.Web.Mvc;

namespace Demo_Mvc5
{

    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //filters.Add(new HandleErrorAttribute());
            filters.Add(new LogExceptionFilter());  //Filter一般捕捉controller内部处理
        }
    }
}
