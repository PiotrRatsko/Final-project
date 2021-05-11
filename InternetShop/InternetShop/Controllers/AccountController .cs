using InternetShop.Domain.Entities;
using InternetShop.Domain.Repositories;
using InternetShop.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace InternetShop.Controllers
{
    public class AccountController : Controller
    {
        readonly IProductRepository _product;
        readonly IUserRepository _user;
        public AccountController(IProductRepository product, IUserRepository user)
        {
            _product = product;
            _user = user;
        }

        [HttpGet]
        public IActionResult Login()
        {
            ViewBag.TotalQuantity = _user.GetUserByEmail(User.Identity.Name)?.Cart.TotalQuantity;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            ViewBag.TotalQuantity = _user.GetUserByEmail(User.Identity.Name)?.Cart.TotalQuantity;
            if (ModelState.IsValid)
            {
                UserModel user = _user.GetUserByEmailAndPassword(loginModel.Email, loginModel.Password);
                if (user != null)
                {
                    await Authenticate(loginModel.Email); // аутентификация

                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Not valid password or/and e-mail");
            }
            return View(loginModel);
        }

        [HttpGet]
        public IActionResult Register()
        {
            ViewBag.TotalQuantity = _user.GetUserByEmail(User.Identity.Name)?.Cart.TotalQuantity;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterModel registerModel)
        {
            ViewBag.TotalQuantity = _user.GetUserByEmail(User.Identity.Name)?.Cart.TotalQuantity;
            if (ModelState.IsValid)
            {
                UserModel user = _user.GetUserByEmail(registerModel.Email);
                if (user == null)
                {
                    // добавляем пользователя в бд
                    _user.AddUser(new UserModel { Email = registerModel.Email, Password = registerModel.Password });

                    await Authenticate(registerModel.Email); // аутентификация

                    return RedirectToAction("Index", "Home");
                }
                else
                    ModelState.AddModelError("", "Not valid password or/and e-mail");
            }
            return View(registerModel);
        }

        private async Task Authenticate(string userName)
        {
            // создаем один claim
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userName)
            };
            // создаем объект ClaimsIdentity
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            // установка аутентификационных куки
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
    }
}