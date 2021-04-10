using InternetShop.Domain;
using InternetShop.Domain.Repositories;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace InternetShop.Controllers
{
    public class HomeController : Controller
    {
        readonly IStoreRepository _repo;
        public HomeController(IStoreRepository repo)
        {
            _repo = repo;
        }

        public async Task<IActionResult> Error()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Index()
        {
            ViewBag.Motos = _repo.GetFilteredProducts("moto", null, null);
            ViewBag.Suhies = _repo.GetFilteredProducts("sushi", null, null);
            ViewBag.TotalQuantity = _repo.GetUserByEmail(User.Identity.Name)?.Cart.TotalQuantity;
            return View();
        }

        public IActionResult Add2Cart(Guid guid)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }
            _repo.AddToCart(guid, User.Identity.Name);
            return RedirectToAction("Index", "Home");
        }
    }
}