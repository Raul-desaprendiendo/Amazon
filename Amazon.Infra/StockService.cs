using Amazon.Core.Models;
using Amazon.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;

namespace Amazon.Infra
{
    public class StockService : IStockService
    {
        private ServiceReference1.IService _stockService;
        public StockService()
        {
            Binding binding = new BasicHttpBinding();
            EndpointAddress endpointAddress = new EndpointAddress("http://localhost:59462/Service.svc?wsdl");
            _stockService = new ServiceReference1.ServiceClient(binding, endpointAddress);
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
            ServiceReference1.ProductStock p = new ServiceReference1.ProductStock { Ammount = product.Ammount, Id = product.Id };
            return _stockService.UpdateProductStock(p);
        }
    }
}
