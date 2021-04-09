using InternetShop.Domain;
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
            ViewBag.Motos = _dataManager.Repository.Store.Products.Where(prd => prd.Category.Equals("moto", StringComparison.OrdinalIgnoreCase));
            ViewBag.Suhies = _dataManager.Repository.Store.Products.Where(prd => prd.Category.Equals("sushi", StringComparison.OrdinalIgnoreCase));
            ViewBag.TotalQuantity = _dataManager.Repository.GetUser(User.Identity.Name)?.Cart.TotalQuantity;
            return View();
        }

        public IActionResult Add2Cart(Guid guid)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }
            _dataManager.Repository.AddToCart(guid, User.Identity.Name);
            return RedirectToAction("Index", "Home");
        }
    }
}