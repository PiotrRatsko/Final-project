using InternetShop.Service;
using Microsoft.AspNetCore.Mvc;
using System;

namespace InternetShop.Controllers
{
    public class CartController : Controller
    {
        readonly StoreService _service;
        public CartController(StoreService service)
        {
            _service = service;
        }
        public IActionResult Index()
        {
            ViewBag.Products = _service.Cart.CartItems;
            return View(_service);
        }

        public IActionResult PlusQuantity(Guid guid)
        {
            _service.Cart.CartItems[_service.GetProductById(guid)]++;
            return RedirectToAction("Index", "Cart");
        }

        public IActionResult MinusQuantity(Guid guid)
        {
            if (_service.Cart.CartItems[_service.GetProductById(guid)] != 1)
            {
                _service.Cart.CartItems[_service.GetProductById(guid)]--;
            }
            return RedirectToAction("Index", "Cart");
        }

        public IActionResult RemoveProduct(Guid guid)
        {
            _service.Cart.CartItems.Remove(_service.GetProductById(guid));
            return RedirectToAction("Index", "Cart");
        }
    }
}
