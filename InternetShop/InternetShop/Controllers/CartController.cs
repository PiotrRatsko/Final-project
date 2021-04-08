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
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }
            ViewBag.TotalQuantity = _dataManager.StoreRepository.Store.Cart.TotalQuantity;
            ViewBag.Products = _dataManager.StoreRepository.Store.Cart.CartItems;
            return View(_dataManager.StoreRepository.Store);
        }

        public IActionResult PlusQuantity(Guid guid)
        {
            _dataManager.StoreRepository.PlusQuantity(guid);
            return RedirectToAction("Index", "Cart");
        }

        public IActionResult MinusQuantity(Guid guid)
        {
            _dataManager.StoreRepository.MinusQuantity(guid);
            return RedirectToAction("Index", "Cart");
        }

        public IActionResult RemoveProductFromCard(Guid guid)
        {
            _dataManager.StoreRepository.RemoveProductFromCard(guid);
            return RedirectToAction("Index", "Cart");
        }
    }
}
