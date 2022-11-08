using Microsoft.AspNetCore.Server.IIS.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class ManageStore : IStores, IDisposable
    {
        private bool disposedValue;
        private readonly ApplicationDbContext db;
        public ManageStore(ApplicationDbContext _db)
        {
            db = _db;
        }

        public bool Delete(int id)
        {
            Store st = db.Stores.Find(id);
            if (st != null)
            {
                db.Stores.Remove(st);
                return true;
            }
            return false;
        }

        public bool Edit(Store model)
        {
            Store st = db.Stores.Find(model.Id);
            if (st != null)
            {
                st.Name = model.Name;
                st.Mbrand = model.Mbrand;
                st.SalePrice = model.SalePrice;
                st.PurchPrice = model.PurchPrice;
                st.pro_loss = model.pro_loss;
                st.Discount = model.Discount;
                st.Dates = model.Dates;
                st.CreateDate = DateTime.Now;
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public IList<Store> GetBrandsales(FillterBrand br)
        {
            var data = new List<Store>();
            data = db.Stores.Where(x => x.Dates.Date >= br.fromDate.Date && x.Dates.Date <= br.endDate.Date && x.Mbrand == br.brand).Distinct().ToList();
            return data;
        }

        public IList<Store> GetSales(Sales sales)
        {
            var data = new List<Store>();
            data = db.Stores.Where(x => x.Dates.Date >= sales.fromDate.Date && x.Dates.Date <= sales.endDate.Date).Distinct().ToList();
            return data;
        }

        public bool Post(Store model)
        {
            Store st = new Store();
            st.Name = model.Name;
            st.Mbrand = model.Mbrand;
            st.SalePrice = model.SalePrice;
            st.PurchPrice = model.PurchPrice;
            st.pro_loss = model.pro_loss;
            st.Discount = model.Discount;
            st.Dates = model.Dates;
            st.CreateDate = DateTime.Now;
            db.Stores.Add(st);
            db.SaveChanges();
            return true;
        }

        public IList<ProfitLoss> ProfitLoss()
        {
            var data = new List<ProfitLoss>();
            try
            {
                var result = db.Stores.Distinct().ToList();
                foreach (var item in result)
                {
                    var res = new ProfitLoss();
                    if (item.PurchPrice > item.SalePrice)
                    {
                        var dis = item.Discount / 100;
                        var disAmount = item.SalePrice * dis;
                        var disAmount1 = item.PurchPrice - item.SalePrice;
                        res.Profit = disAmount1 - disAmount ;
                        res.Loss = 0;
                    }
                    else
                    {
                        var dis = item.Discount / 100;
                        var dis1 = item.SalePrice * dis;
                        var disAmount = item.SalePrice - dis1;
                        res.Profit = item.PurchPrice - disAmount;
                        res.Loss = item.SalePrice - disAmount;
                        res.Profit = 0;
                    }
                    res.Name = item.Name;
                    res.Mbrand = item.Mbrand;
                    res.Discount = item.Discount;
                    data.Add(res);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return data;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~ManageStore()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
