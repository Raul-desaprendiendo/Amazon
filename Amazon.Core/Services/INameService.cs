using Amazon.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon.Core.Services
{
    public interface INameService
    {
        List<ProductName> GetProductsNames();
        string GetProductNameById(int id);
        bool UpdateProductName(int id, string name);
    }
}
