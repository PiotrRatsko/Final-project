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
        readonly IStoreRepository _repo;
        //readonly LoginModel _loginModel;
        //readonly RegisterModel _registerModel;
        public AccountController(IStoreRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IActionResult Login()
        {
            ViewBag.TotalQuantity = _repo.GetUserByEmail(User.Identity.Name)?.Cart.TotalQuantity;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            ViewBag.TotalQuantity = _repo.GetUserByEmail(User.Identity.Name)?.Cart.TotalQuantity;
            if (ModelState.IsValid)
            {
                User user = _repo.GetUserByEmailAndPassword(loginModel.Email, loginModel.Password);
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
            ViewBag.TotalQuantity = _repo.GetUserByEmail(User.Identity.Name)?.Cart.TotalQuantity;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterModel registerModel)
        {
            ViewBag.TotalQuantity = _repo.GetUserByEmail(User.Identity.Name)?.Cart.TotalQuantity;
            if (ModelState.IsValid)
            {
                User user = _repo.GetUserByEmail(registerModel.Email);
                if (user == null)
                {
                    // добавляем пользователя в бд
                    _repo.AddUser(new User { Email = registerModel.Email, Password = registerModel.Password });

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