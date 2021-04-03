using InternetShop.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace InternetShop.Controllers
{

    public class ProductDetailController : Controller
    {
        ItemContext _context;
        public ProductDetailController(ItemContext context)
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