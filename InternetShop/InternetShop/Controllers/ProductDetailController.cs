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
            ViewBag.Product = _dataManager.StoreService.GetProductById(guid);
            return View(_dataManager.StoreService.Store);
        }

        public IActionResult Add2Cart(Guid guid)
        {
            _dataManager.StoreService.AddToCart(guid);
            return RedirectToAction("Index", "ProductDetail", new { guid });
        }
    }
}