using InternetShop.Service;
using Microsoft.AspNetCore.Mvc;

namespace InternetShop.Controllers
{
    public class CartController : Controller
    {
        readonly CartService _cartService;
        readonly ProductService _service;
        public CartController(ProductService service, CartService cartService)
        {
            _cartService = cartService;
            _service = service;
        }
        public IActionResult Index()
        {
            return View(_service);
        }
    }
}
