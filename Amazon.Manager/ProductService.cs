using Amazon.Core.Models;
using Amazon.Core.Services;
using Amazon.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon.Manager
{
    public class ProductService
    {
        private INameService _nameService;
        private IStockService _stockService;
        private IPriceService _priceService;

        public ProductService()
        {
            _nameService = new NameService();
            _stockService = new StockService();
            _priceService = new PriceService();
        }

        public List<Product> GetProducts()
        {
            List<Product> products = new List<Product>();
            var productNames = _nameService.GetProductsNames();
            foreach (var p in productNames)
            {
                var stock = _stockService.GetProductStockById(p.Id);
                var price = _priceService.GetProductPriceById(p.Id);
                products.Add(new Product { Id = p.Id, Ammount = stock, Name = p.Name, Price = price });
            }
            return products;
        }
    }
}
