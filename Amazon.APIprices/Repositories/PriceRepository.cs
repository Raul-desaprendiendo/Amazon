using Amazon.APIprices.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Amazon.APIprices.Repositories
{
    public class PriceRepository : IPriceRepository
    {
        private static string _path = @"~\..\BBDD\Prices.json";
        public List<ProductPrice> GetAllPrices()
        {
            return ReadBBDD();
        }

        public ProductPrice GetProductPrice(int id)
        {
            return ReadBBDD().FirstOrDefault(p => p.Id == id);
        }

        public bool UpdateProductPrice(ProductPrice product)
        {
            List<ProductPrice> products = ReadBBDD();
            int i = products.FindIndex(p => p.Id == product.Id);
            if (i != -1)
            {
                products[i] = product;
                var json = JsonConvert.SerializeObject(products);
                File.WriteAllText(_path, json);
                return true;
            }
            return false;
        }
        private List<ProductPrice> ReadBBDD()
        {
            string json = File.ReadAllText(_path);
            return JsonConvert.DeserializeObject<List<ProductPrice>>(json);
        }
    }
}
