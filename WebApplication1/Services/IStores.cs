using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public interface IStores
    {
        bool Post(Store model);
        bool Edit(Store model);
        IList<Store> GetSales(Sales sales);
        IList<Store> GetBrandsales(FillterBrand br);
        bool Delete(int id);
        IList<ProfitLoss> ProfitLoss();
    }
}
