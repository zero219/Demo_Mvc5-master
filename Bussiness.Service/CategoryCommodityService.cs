using Bussiness.EFModel.EFFirstDB;
using Bussiness.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Service
{
    public class CategoryCommodityService : BaseService, ICategoryCommodityService
    {
        public CategoryCommodityService(DbContext context) : base(context)
        {

        }
        /// <summary>
        /// 连接查询
        /// </summary>
        /// <param name="categoryId"></param>
        public void QueryCommodityByCategoryId(int categoryId)
        {
            var model = from c in base.Set<User>()
                        join com in base.Set<Company>()
                        on c.CompanyId equals com.Id
                        where c.Id == 2
                        select c;
            foreach (var item in model)
            {

            }
        }

        public override void Dispose()
        {
            base.Dispose();
        }
    }
}
