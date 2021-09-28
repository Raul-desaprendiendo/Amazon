using Amazon.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon.Core.Services
{
    public interface IPriceService
    {
        List<ProductPrice> GetProductsPrices();
        decimal GetProductPriceById(int id);
        bool UpdateProductPrice(int id, decimal price);
    }
}
