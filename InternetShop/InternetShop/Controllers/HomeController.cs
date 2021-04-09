using InternetShop.Domain;
using InternetShop.Domain.Repositories;
using InternetShop.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace InternetShop.Controllers
{
    public class HomeController : Controller
    {
        readonly DataManager _dataManager;
        public HomeController(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        public async Task<IActionResult> Error()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Index()
        {
            ViewBag.TotalQuantity = _dataManager.StoreRepository.GetUser(User.Identity.Name)?.Cart.TotalQuantity;
            return View(_dataManager.StoreRepository.Store);
        }

        public IActionResult Add2Cart(Guid guid)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }
            _dataManager.StoreRepository.AddToCart(guid, User.Identity.Name);
            return RedirectToAction("Index", "Home");
        }
    }
}