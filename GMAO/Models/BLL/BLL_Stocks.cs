using GMAO.Models.DAL;
using GMAO.Models.Entities;

namespace GMAO.Models.BLL
{
    public class BLL_Stocks
    {
        public  void Add(Stocks stocks) => DAL_Stocks.AddStock(stocks);
    }
}
