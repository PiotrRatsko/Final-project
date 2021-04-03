using InternetShop.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace InternetShop.Controllers
{

    public class ProductDetailController : Controller
    {
        StoreContext _context;
        public ProductDetailController(StoreContext context)
        {
            _context = context;
        }
        public IActionResult Index(Guid guid)
        {
            ViewBag.Product = _context.GetProductById(guid);
            return View(_context);
        }
    }
}