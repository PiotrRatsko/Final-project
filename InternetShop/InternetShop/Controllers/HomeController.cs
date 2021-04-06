using InternetShop.Models;
using InternetShop.Service;
using Microsoft.AspNetCore.Mvc;
using System;

namespace InternetShop.Controllers
{
    public class HomeController : Controller
    {
        readonly StoreService _service;
        public HomeController(StoreService service)
        {
            _service = service;
        }
        public IActionResult Index()
        {
            return View(_service.Store);
        }

        public IActionResult Add2Cart(Guid guid)
        {
            _service.AddToCart(guid);
            return RedirectToAction("Index", "Home");
        }
    }
}
