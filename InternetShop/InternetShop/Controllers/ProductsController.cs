using Microsoft.AspNetCore.Mvc;
using System;
using InternetShop.Domain;
using System.Linq;
using InternetShop.Domain.Repositories;

namespace InternetShop.Controllers
{
    public class ProductsController : Controller
    {
        readonly IProductRepository _product;
        readonly IUserRepository _user;
        public ProductsController(IProductRepository product, IUserRepository user)
        {
            _product = product;
            _user = user;
        }
        public IActionResult Index(string category, string price, string brand)
        {
            ViewBag.TotalQuantity = _user.GetUserByEmail(User.Identity.Name)?.Cart.TotalQuantity;
            ViewBag.AllProducts = _product.GetFilteredProducts(null, null, null);
            ViewBag.Products = _product.GetFilteredProducts(category, price, brand);
            ViewData["Category"] = category;
            ViewData["Price"] = price;
            ViewData["Brand"] = brand;
            ViewBag.BMW_Count = _product.GetFilteredProducts(null, null, "BMW").Count;
            ViewBag.Honda_Count = _product.GetFilteredProducts(null, null, "Honda").Count;
            ViewBag.Minsk_Count = _product.GetFilteredProducts(null, null, "Minsk").Count;
            ViewBag.SushiVesla_Count = _product.GetFilteredProducts(null, null, "SushiVesla").Count;
            ViewBag.Sushitime_Count = _product.GetFilteredProducts(null, null, "Sushitime").Count;
            ViewBag.TokiNY_Count = _product.GetFilteredProducts(null, null, "TokiNY").Count;
            return View();
        }
        public IActionResult Add2Cart(Guid guid, string category, string price, string brand)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }
            _user.AddToCart(_product.GetProductById(guid), User.Identity.Name);
            return RedirectToAction("Index", "Products", new { category, price, brand });
        }
    }
}
