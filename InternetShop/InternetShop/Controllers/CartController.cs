using InternetShop.Service;
using Microsoft.AspNetCore.Mvc;

namespace InternetShop.Controllers
{
    public class CartController : Controller
    {
        //readonly CartService _cartService;
        readonly ProductService _service;
        public CartController(ProductService service/*, CartService cartService*/)
        {
            //_cartService = cartService;
            _service = service;
        }
        public IActionResult Index()
        {
            foreach (var item in _service.Cart.CartItems)
            {
                var i = item;
            }
            ViewBag.Products = _service.Cart.CartItems;
            return View(_service);
        }
    }
}
