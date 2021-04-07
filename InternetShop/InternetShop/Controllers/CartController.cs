using InternetShop.Service;
using Microsoft.AspNetCore.Mvc;
using System;

namespace InternetShop.Controllers
{
    public class CartController : Controller
    {
        readonly IStoreService _service;
        public CartController(StoreService service)
        {
            _service = service;
        }
        public IActionResult Index()
        {
            ViewBag.Products = _service.Store.Cart.CartItems;
            return View(_service.Store);
        }

        public IActionResult PlusQuantity(Guid guid)
        {
            _service.PlusQuantity(guid);
            return RedirectToAction("Index", "Cart");
        }

        public IActionResult MinusQuantity(Guid guid)
        {
            _service.MinusQuantity(guid);
            return RedirectToAction("Index", "Cart");
        }

        public IActionResult RemoveProductFromCard(Guid guid)
        {
            _service.RemoveProductFromCard(guid);
            return RedirectToAction("Index", "Cart");
        }
    }
}
