using InternetShop.Domain;
using InternetShop.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;

namespace InternetShop.Controllers
{
    public class CartController : Controller
    {
        readonly IStoreRepository _repo;
        public CartController(IStoreRepository repo)
        {
            _repo = repo;
        }
        public IActionResult Index()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }
            ViewBag.TotalSum = _repo.GetUserByEmail(User.Identity.Name)?.Cart.TotalSum;
            ViewBag.TotalQuantity = _repo.GetUserByEmail(User.Identity.Name)?.Cart.TotalQuantity;
            ViewBag.Products = _repo.GetUserByEmail(User.Identity.Name)?.Cart.CartItems;
            return View();
        }

        public IActionResult PlusQuantity(Guid guid)
        {
            _repo.PlusQuantity(guid, User.Identity.Name);
            return RedirectToAction("Index", "Cart");
        }

        public IActionResult MinusQuantity(Guid guid)
        {
            _repo.MinusQuantity(guid, User.Identity.Name);
            return RedirectToAction("Index", "Cart");
        }

        public IActionResult RemoveProductFromCard(Guid guid)
        {
            _repo.RemoveProductFromCard(guid, User.Identity.Name);
            return RedirectToAction("Index", "Cart");
        }
    }
}
