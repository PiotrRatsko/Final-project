using InternetShop.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternetShop.Controllers
{
    public class HomeController : Controller
    {
        ItemContext _context;
        public HomeController(ItemContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context);
        }
    }
}
