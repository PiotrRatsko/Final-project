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
            ViewBag.TotalSum = _dataManager.StoreRepository.GetUser(User.Identity.Name)?.Cart.TotalSum;
            ViewBag.TotalQuantity = _dataManager.StoreRepository.GetUser(User.Identity.Name)?.Cart.TotalQuantity;
            ViewBag.Products = _dataManager.StoreRepository.GetUser(User.Identity.Name)?.Cart.CartItems;
            return View();
        }

        public IActionResult PlusQuantity(Guid guid)
        {
            _dataManager.StoreRepository.PlusQuantity(guid, User.Identity.Name);
            return RedirectToAction("Index", "Cart");
        }

        public IActionResult MinusQuantity(Guid guid)
        {
            _dataManager.StoreRepository.MinusQuantity(guid, User.Identity.Name);
            return RedirectToAction("Index", "Cart");
        }

        public IActionResult RemoveProductFromCard(Guid guid)
        {
            _dataManager.StoreRepository.RemoveProductFromCard(guid, User.Identity.Name);
            return RedirectToAction("Index", "Cart");
        }
    }
}
