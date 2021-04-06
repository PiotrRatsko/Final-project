using InternetShop.Service;
using Microsoft.AspNetCore.Mvc;

namespace InternetShop.Controllers
{
    public class CartController : Controller
    {
        readonly CartService _service;
        public CartController(CartService service)
        {
            _service = service;
        }
        public IActionResult Index()
        {
            return View(_service);
        }
    }
}
