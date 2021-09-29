using Amazon.APIprices.Models;
using Amazon.APIprices.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Amazon.APIprices.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PriceController : ControllerBase
    {
        private IPrice _priceService;

        public PriceController()
        {
            _priceService = new PriceService();
        }

        [HttpGet]
        public List<ProductPrice> GetPrice()
        {
            return _priceService.GetPrices();
        }

        [HttpGet("{id}")]
        public ProductPrice GetPriceById(int id)
        {
            return _priceService.GetProductPriceById(id);
        }

        [HttpPut]
        public bool Update(ProductPrice product)
        {
            return _priceService.UpdateProductPrice(product);
        }
    }
}
