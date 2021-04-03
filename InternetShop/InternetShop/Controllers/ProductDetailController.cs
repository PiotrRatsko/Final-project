using InternetShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace InternetShop.Controllers
{

    public class ProductDetailController : Controller
    {
        ItemContext _context;
        public ProductDetailController(ItemContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context);
        }
    }
}