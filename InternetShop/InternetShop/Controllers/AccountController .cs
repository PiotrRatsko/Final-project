using InternetShop.Domain;
using InternetShop.Domain.Entities;
using InternetShop.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace InternetShop.Controllers
{
    public class AccountController : Controller
    {
        readonly DataManager _dataManager;
        public AccountController(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View(_dataManager.StoreService.Store);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                User user = _dataManager.StoreService.Store.Users.FirstOrDefault(u => u.Email == loginModel.Email && u.Password == loginModel.Password);
                if (user != null)
                {
                    await Authenticate(loginModel.Email); // аутентификация

                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
            return View(_dataManager.StoreService.Store);
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View(_dataManager.StoreService.Store);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterModel registerModel)
        {
            if (ModelState.IsValid)
            {
                User user = _dataManager.StoreService.Store.Users.FirstOrDefault(u => u.Email == registerModel.Email);
                if (user == null)
                {
                    // добавляем пользователя в бд
                    _dataManager.StoreService.Store.Users.Add(new User { Email = registerModel.Email, Password = registerModel.Password });

                    await Authenticate(registerModel.Email); // аутентификация

                    return RedirectToAction("Index", "Home");
                }
                else
                    ModelState.AddModelError("", "Not valid password or/and e-mail");
            }
            return View(_dataManager.StoreService.Store);
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
            return RedirectToAction("Login", "Account");
        }
    }
}