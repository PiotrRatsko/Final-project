using InternetShop.Service;
using InternetShop.Constants;
using Microsoft.AspNetCore.Mvc;
using System;

namespace InternetShop.Controllers
{
    public class ProductsController : Controller
    {
        readonly StoreService _service;
        public ProductsController(StoreService service)
        {
            _service = service;
        }
        public IActionResult Index(string category, string price, string brand)
        {
            ViewBag.Products = _service.GetFilteredProducts(category, price, brand);
            ViewData["Category"] = category;
            ViewData["Price"] = price;
            ViewData["Brand"] = brand;
            return View(_service.Store);
        }
        public IActionResult Add2Cart(Guid guid, string category, string price, string brand)
        {
            _service.AddToCart(guid);
            return RedirectToAction("Index", "Products", new { category, price, brand });
        }
    }
}
