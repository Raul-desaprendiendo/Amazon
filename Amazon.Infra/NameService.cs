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
    public class NameService : INameService
    {
        private readonly string _url = @"http://localhost:44308/name";
        public string GetProductNameById(int id)
        {
            using (WebClient http = new WebClient())
            {
                string json = http.DownloadString($"{_url}/{id}");
                var product= JsonConvert.DeserializeObject<ProductName>(json);
                return product.Name;
            }
        }

        public List<ProductName> GetProductsNames()
        {
            using (WebClient http = new WebClient())
            {
                string json = http.DownloadString($"{_url}");
                var products = JsonConvert.DeserializeObject<List<ProductName>>(json);
                return products;
            }
        }

        public bool UpdateProductName(int id, string name)
        {
            using (WebClient http = new WebClient())
            {
                var productName = new ProductName() { Id = id, Name = name };
                var body = JsonConvert.SerializeObject(productName);
                string json = http.UploadString($"{_url}",body);
                return Boolean.Parse(json);
            }
        }
    }
}
