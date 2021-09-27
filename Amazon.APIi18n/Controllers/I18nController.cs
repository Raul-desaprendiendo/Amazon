using Amazon.APIi18n.Models;
using Amazon.APIi18n.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Amazon.APIi18n.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class I18nController : ControllerBase
    {
        private NameService _nameService;

        public I18nController()
        {
            _nameService = new NameService();
        }

        [HttpGet]
        public List<ProductName> Index()
        {
            return _nameService.GetNames();
        }

        [HttpGet("{id}")]
        public ProductName GetNameById(int id)
        {
            return _nameService.GetProductName(id);
        }

        [HttpPut]
        public bool Update(ProductName product)
        {
            return _nameService.UpdateProductName(product);
        }
    }
}
