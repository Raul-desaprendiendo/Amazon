using Amazon.APIi18n.Models;
using Amazon.APIi18n.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Amazon.APIi18n.Services
{
    public class NameService : IName
    {
        private Func<string,INameRepository> _nameRepository;
        public NameService(Func<string, INameRepository> repository)
        {
            _nameRepository = repository;
        }
        public List<ProductName> GetNames()
        {
            return _nameRepository("English").GetAllNames();
        }

        public ProductName GetProductName(int id)
        {
            if (!ProductExists(id))
            {
                return null;
            }
            return _nameRepository("English").GetProductName(id);
        }

        public bool ProductExists(int id)
        {
            return _nameRepository("English").GetProductName(id) != null;
        }

        public bool UpdateProductName(ProductName product)
        {
            if (!ProductExists(product.Id))
            {
                return false;
            }
            return _nameRepository("English").UpdateProductName(product);
        }
    }
}
