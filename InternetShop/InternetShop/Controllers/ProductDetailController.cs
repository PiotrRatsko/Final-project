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
        readonly IStoreRepository _repo;
        public ProductDetailController(IStoreRepository repo)
        {
            _repo = repo;
        }

        public IActionResult Index(Guid guid)
        {
            ViewBag.TotalQuantity = _repo.GetUserByEmail(User.Identity.Name)?.Cart.TotalQuantity;
            ViewBag.Product = _repo.GetProductById(guid);
            ViewBag.AllProducts = _repo.GetFilteredProducts(null, null, null);

            ViewBag.BMW_Count = _repo.GetFilteredProducts(null, null, "BMW").Count;
            ViewBag.Honda_Count = _repo.GetFilteredProducts(null, null, "Honda").Count;
            ViewBag.Minsk_Count = _repo.GetFilteredProducts(null, null, "Minsk").Count;
            ViewBag.SushiVesla_Count = _repo.GetFilteredProducts(null, null, "SushiVesla").Count;
            ViewBag.Sushitime_Count = _repo.GetFilteredProducts(null, null, "Sushitime").Count;
            ViewBag.TokiNY_Count = _repo.GetFilteredProducts(null, null, "TokiNY").Count;
            return View();
        }

        public IActionResult Add2Cart(Guid guid)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }
            _repo.AddToCart(guid, User.Identity.Name);
            return RedirectToAction("Index", "ProductDetail", new { guid });
        }
    }
}