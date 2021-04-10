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
            ViewBag.TotalQuantity = _dataManager.Repository.GetUserByEmail(User.Identity.Name)?.Cart.TotalQuantity;
            ViewBag.Product = _dataManager.Repository.GetProductById(guid);
            ViewBag.AllProducts = _dataManager.Repository.GetFilteredProducts(null, null, null);

            ViewBag.BMW_Count = _dataManager.Repository.GetFilteredProducts(null, null, "BMW").Count;
            ViewBag.Honda_Count = _dataManager.Repository.GetFilteredProducts(null, null, "Honda").Count;
            ViewBag.Minsk_Count = _dataManager.Repository.GetFilteredProducts(null, null, "Minsk").Count;
            ViewBag.SushiVesla_Count = _dataManager.Repository.GetFilteredProducts(null, null, "SushiVesla").Count;
            ViewBag.Sushitime_Count = _dataManager.Repository.GetFilteredProducts(null, null, "Sushitime").Count;
            ViewBag.TokiNY_Count = _dataManager.Repository.GetFilteredProducts(null, null, "TokiNY").Count;
            return View();
        }

        public IActionResult Add2Cart(Guid guid)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }
            _dataManager.Repository.AddToCart(guid, User.Identity.Name);
            return RedirectToAction("Index", "ProductDetail", new { guid });
        }
    }
}