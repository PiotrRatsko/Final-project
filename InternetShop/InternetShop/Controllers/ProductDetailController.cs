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
        readonly IProductRepository _product;
        readonly IUserRepository _user;
        public ProductDetailController(IProductRepository product, IUserRepository user)
        {
            _product = product;
            _user = user;
        }

        public IActionResult Index(Guid guid)
        {
            ViewBag.TotalQuantity = _user.GetUserByEmail(User.Identity.Name)?.Cart.TotalQuantity;
            ViewBag.Product = _product.GetProductById(guid);
            ViewBag.AllProducts = _product.GetFilteredProducts(null, null, null);

            ViewBag.BMW_Count = _product.GetFilteredProducts(null, null, "BMW").Count;
            ViewBag.Honda_Count = _product.GetFilteredProducts(null, null, "Honda").Count;
            ViewBag.Minsk_Count = _product.GetFilteredProducts(null, null, "Minsk").Count;
            ViewBag.SushiVesla_Count = _product.GetFilteredProducts(null, null, "SushiVesla").Count;
            ViewBag.Sushitime_Count = _product.GetFilteredProducts(null, null, "Sushitime").Count;
            ViewBag.TokiNY_Count = _product.GetFilteredProducts(null, null, "TokiNY").Count;
            return View();
        }

        public IActionResult Add2Cart(Guid guid)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }
            _user.AddToCart(_product.GetProductById(guid), User.Identity.Name);
            return RedirectToAction("Index", "ProductDetail", new { guid });
        }
    }
}