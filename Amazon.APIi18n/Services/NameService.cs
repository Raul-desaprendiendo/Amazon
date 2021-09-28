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
        private INameRepository _nameRepository;
        public NameService()
        {
            _nameRepository = new SpanishRepository();
        }
        public List<ProductName> GetNames()
        {
            return _nameRepository.GetAllNames();
        }

        public ProductName GetProductName(int id)
        {
            if (!ProductExists(id))
            {
                return null;
            }
            return _nameRepository.GetProductName(id);
        }

        public bool ProductExists(int id)
        {
            return _nameRepository.GetProductName(id) != null;
        }

        public bool UpdateProductName(ProductName product)
        {
            if (!ProductExists(product.Id))
            {
                return false;
            }
            return _nameRepository.UpdateProductName(product);
        }
    }
}
