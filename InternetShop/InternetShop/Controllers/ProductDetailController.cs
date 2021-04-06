using InternetShop.Models;
using InternetShop.Service;
using Microsoft.AspNetCore.Mvc;
using System;

namespace InternetShop.Controllers
{
    public class ProductDetailController : Controller
    {
        readonly StoreService _service;
        public ProductDetailController(StoreService service)
        {
            _service = service;
        }
        public IActionResult Index(Guid guid)
        {
            ViewBag.Product = _service.GetProductById(guid);
            return View(_service);
        }

        public IActionResult Add2Cart(Guid guid)
        {
            _service.AddToCart(guid);
            return RedirectToAction("Index", "ProductDetail", new { guid = guid });
        }
    }
}