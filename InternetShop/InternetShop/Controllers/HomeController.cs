using InternetShop.Models;
using InternetShop.Service;
using Microsoft.AspNetCore.Mvc;
using System;

namespace InternetShop.Controllers
{
    public class HomeController : Controller
    {
        readonly ProductService _service;
        public HomeController(ProductService service)
        {
            _service = service;
        }
        public IActionResult Index()
        {
            return View(_service);
        }

        public IActionResult Add2Cart(Guid guid)
        {
            _service.AddToCart(guid);
            return RedirectToAction("Index", "Home");
        }
    }
}
