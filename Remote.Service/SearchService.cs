using Remote.Interface;
using Remote.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Remote.Service
{
    //public class SearchService : ISearch
    //{
    //    public PageResults<CommodityModel> QueryCommodityPage(int pageIndex, int pageSize, string keyword, List<int> categoryIdList, string priceFilter, string priceOrderBy)
    //    {
    //        RemoteSearchService.SearcherClient client = null;

    //        try
    //        {
    //            client = new RemoteSearchService.SearcherClient();
    //            string result = client.QueryCommodityPage(pageIndex, pageSize, keyword, categoryIdList, priceFilter, priceOrderBy);

    //            client.Close();//会关闭链接，但是如果网络异常了，会抛出异常而且关闭不了
    //            return Newtonsoft.Json.JsonConvert.DeserializeObject<PageResults<CommodityModel>>(result);
    //        }
    //        catch (Exception ex)
    //        {
    //            Console.WriteLine(ex.Message);
    //            if (client != null)
    //                client.Abort();
    //            throw ex;
    //        }
    //    }
    //}
}
