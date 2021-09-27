using Amazon.APIi18n.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Amazon.APIi18n.Repositories
{
    interface INameRepository
    {
        ProductName GetProductName(int id);

        List<ProductName> GetAllNames();

        bool UpdateProductName(ProductName product);
    }
}
