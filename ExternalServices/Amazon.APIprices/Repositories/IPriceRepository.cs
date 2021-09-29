using Amazon.APIprices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Amazon.APIprices.Repositories
{
    interface IPriceRepository
    {
        ProductPrice GetProductPrice(int id);
        List<ProductPrice> GetAllPrices();
        bool UpdateProductPrice(ProductPrice product);
    }
}
