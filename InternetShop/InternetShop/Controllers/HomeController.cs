using InternetShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace InternetShop.Controllers
{
    public class HomeController : Controller
    {
        StoreContext _context;
        public HomeController(StoreContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context);
        }
    }
}
