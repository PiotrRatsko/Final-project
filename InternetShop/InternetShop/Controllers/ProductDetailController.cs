using InternetShop.Domain;
using InternetShop.Domain.Repositories;
using InternetShop.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace InternetShop.Controllers
{
    public class ProductDetailController : Controller
    {
        readonly DataManager _dataManager;
        public ProductDetailController(DataManager dataManager)
        {
            _dataManager = dataManager;
        }
        public IActionResult Index(Guid guid)
        {
            ViewBag.TotalQuantity = _dataManager.StoreRepository.Store.Cart.TotalQuantity;
            ViewBag.Product = _dataManager.StoreRepository.GetProductById(guid);
            return View(_dataManager.StoreRepository.Store);
        }

        public IActionResult Add2Cart(Guid guid)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }
            _dataManager.StoreRepository.AddToCart(guid);
            return RedirectToAction("Index", "ProductDetail", new { guid });
        }
    }
}