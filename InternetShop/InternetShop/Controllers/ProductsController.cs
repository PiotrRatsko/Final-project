using InternetShop.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternetShop.Controllers
{
    public class ProductsController : Controller
    {
        readonly ProductService _service;
        public ProductsController(ProductService service)
        {
            _service = service;
        }
        public IActionResult Index(string category)
        {
            if (!string.IsNullOrEmpty(category))
            {
                ViewBag.Products = _service.GetProductByCategory(category);
                ViewData["Category"] = category;
            }
            else
            {
                ViewBag.Products = _service.Products;
                ViewData["Category"] = "All categories";
            }
            return View(_service);
        }
    }
}
