using InternetShop.Models;
using InternetShop.Service;
using Microsoft.AspNetCore.Mvc;
using System;

namespace InternetShop.Controllers
{

    public class ProductDetailController : Controller
    {
        readonly ProductService _service;
        public ProductDetailController(ProductService service)
        {
            _service = service;
        }
        public IActionResult Index(Guid guid)
        {
            ViewBag.Product = _service.GetProductById(guid);
            return View(_service);
        }
    }
}