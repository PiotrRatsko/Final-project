using InternetShop.Domain;
using InternetShop.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;

namespace InternetShop.Controllers
{
    public class CartController : Controller
    {
        readonly DataManager _dataManager;
        public CartController(DataManager dataManager)
        {
            _dataManager = dataManager;
        }
        public IActionResult Index()
        {
            ViewBag.Products = _dataManager.StoreService.Store.Cart.CartItems;
            return View(_dataManager.StoreService.Store);
        }

        public IActionResult PlusQuantity(Guid guid)
        {
            _dataManager.StoreService.PlusQuantity(guid);
            return RedirectToAction("Index", "Cart");
        }

        public IActionResult MinusQuantity(Guid guid)
        {
            _dataManager.StoreService.MinusQuantity(guid);
            return RedirectToAction("Index", "Cart");
        }

        public IActionResult RemoveProductFromCard(Guid guid)
        {
            _dataManager.StoreService.RemoveProductFromCard(guid);
            return RedirectToAction("Index", "Cart");
        }
    }
}
