using Amazon.Core.Models;
using Amazon.Core.Services;
using Amazon.Infra.ServiceReferenceStock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon.Infra
{
    public class StockService : IStockService
    {
        private IService _stockService;
        public StockService()
        {
            _stockService = new ServiceClient();
        }
        public List<Core.Models.ProductStock> GetProductsStock()
        {
            var products = from product in _stockService.GetAllStock()
                           select new Core.Models.ProductStock { Ammount = product.Ammount, Id = product.Id };
            return products.ToList();
        }

        public int GetProductStockById(int id)
        {
            return _stockService.GetProductStockById(id).Ammount;
        }

        public bool ReduceProductStock(int id, int cuantity)
        {
            return _stockService.ReduceItemStock(id, cuantity);
        }

        public bool UpdateProductStock(Core.Models.ProductStock product)
        {
            ServiceReferenceStock.ProductStock p = new ServiceReferenceStock.ProductStock { Ammount = product.Ammount, Id = product.Id };
            return _stockService.UpdateProductStock(p);
        }
    }
}
