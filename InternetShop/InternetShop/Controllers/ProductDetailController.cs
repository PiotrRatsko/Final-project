using InternetShop.Domain;
using InternetShop.Domain.Repositories;
using InternetShop.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

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
            ViewBag.TotalQuantity = _dataManager.StoreRepository.GetUser(User.Identity.Name)?.Cart.TotalQuantity;
            ViewBag.Product = _dataManager.StoreRepository.GetProductById(guid);
            ViewBag.AllProducts = _dataManager.StoreRepository.Store.Products;

            ViewBag.BMW_Count = _dataManager.StoreRepository.Store.Products.Where(i => i.Brand.Equals("BMW", StringComparison.OrdinalIgnoreCase)).Count();
            ViewBag.Honda_Count = _dataManager.StoreRepository.Store.Products.Where(i => i.Brand.Equals("Honda", StringComparison.OrdinalIgnoreCase)).Count();
            ViewBag.Minsk_Count = _dataManager.StoreRepository.Store.Products.Where(i => i.Brand.Equals("Minsk", StringComparison.OrdinalIgnoreCase)).Count();
            ViewBag.SushiVesla_Count = _dataManager.StoreRepository.Store.Products.Where(i => i.Brand.Equals("SushiVesla", StringComparison.OrdinalIgnoreCase)).Count();
            ViewBag.Sushitime_Count = _dataManager.StoreRepository.Store.Products.Where(i => i.Brand.Equals("Sushitime", StringComparison.OrdinalIgnoreCase)).Count();
            ViewBag.TokiNY_Count = _dataManager.StoreRepository.Store.Products.Where(i => i.Brand.Equals("TokiNY", StringComparison.OrdinalIgnoreCase)).Count();
            return View();
        }

        public IActionResult Add2Cart(Guid guid)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }
            _dataManager.StoreRepository.AddToCart(guid, User.Identity.Name);
            return RedirectToAction("Index", "ProductDetail", new { guid });
        }
    }
}