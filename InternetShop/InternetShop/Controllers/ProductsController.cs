using Microsoft.AspNetCore.Mvc;
using System;
using InternetShop.Domain;
using System.Linq;

namespace InternetShop.Controllers
{
    public class ProductsController : Controller
    {
        readonly DataManager _dataManager;
        public ProductsController(DataManager dataManager)
        {
            _dataManager = dataManager;
        }
        public IActionResult Index(string category, string price, string brand)
        {
            ViewBag.TotalQuantity = _dataManager.Repository.GetUserByEmail(User.Identity.Name)?.Cart.TotalQuantity;
            ViewBag.AllProducts = _dataManager.Repository.GetFilteredProducts(null, null, null);
            ViewBag.Products = _dataManager.Repository.GetFilteredProducts(category, price, brand);
            ViewData["Category"] = category;
            ViewData["Price"] = price;
            ViewData["Brand"] = brand;
            ViewBag.BMW_Count = _dataManager.Repository.GetFilteredProducts(null, null, "BMW").Count;
            ViewBag.Honda_Count = _dataManager.Repository.GetFilteredProducts(null, null, "Honda").Count;
            ViewBag.Minsk_Count = _dataManager.Repository.GetFilteredProducts(null, null, "Minsk").Count;
            ViewBag.SushiVesla_Count = _dataManager.Repository.GetFilteredProducts(null, null, "SushiVesla").Count;
            ViewBag.Sushitime_Count = _dataManager.Repository.GetFilteredProducts(null, null, "Sushitime").Count;
            ViewBag.TokiNY_Count = _dataManager.Repository.GetFilteredProducts(null, null, "TokiNY").Count;
            return View();
        }
        public IActionResult Add2Cart(Guid guid, string category, string price, string brand)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }
            _dataManager.Repository.AddToCart(guid, User.Identity.Name);
            return RedirectToAction("Index", "Products", new { category, price, brand });
        }
    }
}
