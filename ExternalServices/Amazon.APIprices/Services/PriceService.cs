using Amazon.APIprices.Models;
using Amazon.APIprices.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Amazon.APIprices.Services
{
    public class PriceService : IPrice
    {
        private IPriceRepository _priceRepository;
        public PriceService()
        {
            _priceRepository = new PriceRepository();
        }
        public List<ProductPrice> GetPrices()
        {
            return _priceRepository.GetAllPrices();
        }

        public ProductPrice GetProductPriceById(int id)
        {
            if (!ProductExists(id))
            {
                return null;
            }
            return _priceRepository.GetProductPrice(id);
        }

        public bool ProductExists(int id)
        {
            return _priceRepository.GetProductPrice(id) != null;
        }

        public bool UpdateProductPrice(ProductPrice product)
        {
            if (!ProductExists(product.Id))
            {
                return false;
            }
            return _priceRepository.UpdateProductPrice(product);
        }
    }
}
