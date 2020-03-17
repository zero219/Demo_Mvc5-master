using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Interface
{
    public interface ICategoryCommodityService : IBaseService
    {
        void QueryCommodityByCategoryId(int categoryId);
    }
}
