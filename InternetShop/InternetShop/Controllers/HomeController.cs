using InternetShop.Domain.Repositories;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace InternetShop.Controllers
{
    public class HomeController : Controller
    {
        readonly IProductRepository _product;
        readonly IUserRepository _user;
        public HomeController(IProductRepository product, IUserRepository user)
        {
            _product = product;
            _user = user;
        }

        public async Task<IActionResult> Error()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Index()
        {
            ViewBag.Motos = _product.GetFilteredProducts("moto", null, null);
            ViewBag.Suhies = _product.GetFilteredProducts("sushi", null, null);
            ViewBag.TotalQuantity = _user.GetUserByEmail(User?.Identity.Name)?.Cart.TotalQuantity;
            return View();
        }

        public IActionResult Add2Cart(Guid guid)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }
            _user.AddToCart(_product.GetProductById(guid), User.Identity.Name);
            return RedirectToAction("Index", "Home");
        }
    }
}