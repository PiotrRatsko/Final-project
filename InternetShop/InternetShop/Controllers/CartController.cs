using InternetShop.Domain;
using InternetShop.Domain.Entities;
using InternetShop.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;

namespace InternetShop.Controllers
{
    public class CartController : Controller
    {
        readonly IProductRepository _product;
        readonly IUserRepository _user;
        public CartController(IProductRepository product, IUserRepository user)
        {
            _product = product;
            _user = user;
        }

        public IActionResult Index()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }
            ViewBag.TotalSum = _user.GetUserByEmail(User.Identity.Name)?.Cart.TotalSum;
            ViewBag.TotalQuantity = _user.GetUserByEmail(User.Identity.Name)?.Cart.TotalQuantity;
            ViewBag.Products = _user.GetUserByEmail(User.Identity.Name)?.Cart.CartItems;
            return View();
        }

        public IActionResult PlusQuantity(Guid guid)
        {
            _user.PlusQuantity(_product.GetProductById(guid), User.Identity.Name);
            return RedirectToAction("Index", "Cart");
        }

        public IActionResult MinusQuantity(Guid guid)
        {
            _user.MinusQuantity(_product.GetProductById(guid), User.Identity.Name);
            return RedirectToAction("Index", "Cart");
        }

        public IActionResult RemoveProductFromCard(Guid guid)
        {
            _user.RemoveProductFromCard(_product.GetProductById(guid), User.Identity.Name);
            return RedirectToAction("Index", "Cart");
        }
    }
}
