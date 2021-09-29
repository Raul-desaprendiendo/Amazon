using Amazon.APIi18n.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Amazon.APIi18n.Services
{
    public interface IName
    {
        ProductName GetProductName(int id);
        List<ProductName> GetNames();
        bool UpdateProductName(ProductName product);
        bool ProductExists(int id);
    }
}
