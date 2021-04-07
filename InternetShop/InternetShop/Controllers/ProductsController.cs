using Microsoft.AspNetCore.Mvc;
using System;
using InternetShop.Domain;

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
            ViewBag.Products = _dataManager.StoreService.GetFilteredProducts(category, price, brand);
            ViewData["Category"] = category;
            ViewData["Price"] = price;
            ViewData["Brand"] = brand;
            return View(_dataManager.StoreService.Store);
        }
        public IActionResult Add2Cart(Guid guid, string category, string price, string brand)
        {
            _dataManager.StoreService.AddToCart(guid);
            return RedirectToAction("Index", "Products", new { category, price, brand });
        }
    }
}
