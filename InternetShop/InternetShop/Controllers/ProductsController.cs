using Microsoft.AspNetCore.Mvc;
using System;
using InternetShop.Domain.Repositories;

namespace InternetShop.Controllers
{
    public class ProductsController : Controller
    {
        readonly IStoreRepository _repo;
        public ProductsController(IStoreRepository repo)
        {
            _repo = repo;
        }
        public IActionResult Index(string category, string price, string brand)
        {
            ViewBag.TotalQuantity = _repo.GetUserByEmail(User.Identity.Name)?.Cart.TotalQuantity;
            ViewBag.AllProducts = _repo.GetFilteredProducts(null, null, null);
            ViewBag.Products = _repo.GetFilteredProducts(category, price, brand);
            ViewData["Category"] = category;
            ViewData["Price"] = price;
            ViewData["Brand"] = brand;
            ViewBag.BMW_Count = _repo.GetFilteredProducts(null, null, "BMW").Count;
            ViewBag.Honda_Count = _repo.GetFilteredProducts(null, null, "Honda").Count;
            ViewBag.Minsk_Count = _repo.GetFilteredProducts(null, null, "Minsk").Count;
            ViewBag.SushiVesla_Count = _repo.GetFilteredProducts(null, null, "SushiVesla").Count;
            ViewBag.Sushitime_Count = _repo.GetFilteredProducts(null, null, "Sushitime").Count;
            ViewBag.TokiNY_Count = _repo.GetFilteredProducts(null, null, "TokiNY").Count;
            return View();
        }
        public IActionResult Add2Cart(Guid guid, string category, string price, string brand)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }
            _repo.AddToCart(guid, User.Identity.Name);
            return RedirectToAction("Index", "Products", new { category, price, brand });
        }
    }
}
