using Amazon.Core.Models;
using Amazon.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Amazon.Web.Controllers
{
    public class ClientController : Controller
    {
        private ProductService _productService;
        private static List<Product> order = new List<Product>();
        public ClientController()
        {
            _productService = new ProductService();
        }

        public ActionResult Index()
        {
            List<Product> products = _productService.GetProducts();
            return View(products);
        }

        public void AddProduct(Product p)
        {
            order.Add(p);
        }

    }
}