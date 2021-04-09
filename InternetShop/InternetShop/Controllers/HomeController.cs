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
            ViewBag.Motos = _dataManager.StoreRepository.Store.Products.Where(prd => prd.Category.Equals("moto", StringComparison.OrdinalIgnoreCase));
            ViewBag.Suhies = _dataManager.StoreRepository.Store.Products.Where(prd => prd.Category.Equals("sushi", StringComparison.OrdinalIgnoreCase));
            ViewBag.TotalQuantity = _dataManager.StoreRepository.GetUser(User.Identity.Name)?.Cart.TotalQuantity;
            return View();
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