using Amazon.APIi18n.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Amazon.APIi18n.Repositories
{
    public class SpanishRepository : INameRepository
    {
        private static string _path = @"~\..\BBDD\ProductsSpanish.json";
        public List<ProductName> GetAllNames()
        {
            return ReadBBDD();
        }

        public ProductName GetProductName(int id)
        {
            return ReadBBDD().FirstOrDefault(p => p.Id == id);
        }

        public bool UpdateProductName(ProductName product)
        {
            List<ProductName> products = ReadBBDD();
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

        private List<ProductName> ReadBBDD()
        {
            string json = File.ReadAllText(_path);
            return JsonConvert.DeserializeObject<List<ProductName>>(json);
        }
    }
}
