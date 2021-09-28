using Amazon.Core.Models;
using Amazon.Core.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Amazon.Infra
{
    public class PriceService : IPriceService
    {
        private readonly string _url = @"http://localhost:44347/price";

        public decimal GetProductPriceById(int id)
        {
            using (WebClient http = new WebClient())
            {
                string json = http.DownloadString($"{_url}/id");
                var product = JsonConvert.DeserializeObject<ProductPrice>(json);
                return product.Price;
            }
        }

        public List<ProductPrice> GetProductsPrices()
        {
            using (WebClient http = new WebClient())
            {
                string json = http.DownloadString($"{_url}");
                return JsonConvert.DeserializeObject<List<ProductPrice>>(json);
            }
        }

        public bool UpdateProductPrice(int id, decimal price)
        {
            using (WebClient http = new WebClient())
            {
                var productPrice = new ProductPrice() { Id = id, Price = price };
                var body = JsonConvert.SerializeObject(productPrice);
                string json = http.UploadString($"{_url}", body);
                return Boolean.Parse(json);
            }
        }
    }
}
