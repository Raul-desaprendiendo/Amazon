using Amazon.APIprices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Amazon.APIprices.Services
{
    interface IPrice
    {
        ProductPrice GetProductPriceById(int id);
        List<ProductPrice> GetPrices();
        bool UpdateProductPrice(ProductPrice product);
        bool ProductExists(int id);
    }
}
