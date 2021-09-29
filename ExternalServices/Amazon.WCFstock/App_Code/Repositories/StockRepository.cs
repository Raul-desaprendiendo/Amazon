using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

public class StockRepository : IStockRepository
{
    // No me deja poner una ruta relativa porque como lo lanza desde el IIS intenta navegar desde ahí
    private static string _path = @"C:\Users\Raul\source\repos\Amazon\ExternalServices\Amazon.WCFstock\App_Data\Stock.json";

    public List<ProductStock> GetAllStock()
    {
        return ReadBBDD();
    }

    public ProductStock GetProductStockById(int id)
    {
        return ReadBBDD().FirstOrDefault(p => p.Id == id);
    }

    public bool UpdateProductStock(ProductStock product)
    {
        List<ProductStock> products = ReadBBDD();
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

    private List<ProductStock> ReadBBDD()
    {
        string json = File.ReadAllText(_path);
        return JsonConvert.DeserializeObject<List<ProductStock>>(json);
    }
}