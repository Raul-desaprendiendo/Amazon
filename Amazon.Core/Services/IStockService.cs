using Amazon.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon.Core.Services
{
    public interface IStockService
    {
        List<ProductStock> GetProductsStock();
        int GetProductStockById(int id);
        bool ReduceProductStock(int id, int cuantity);
        bool UpdateProductStock(ProductStock product);
    }
}
