﻿using InternetShop.Domain;
using InternetShop.Domain.Repositories;
using InternetShop.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace InternetShop.Controllers
{
    public class HomeController : Controller
    {
        readonly DataManager _dataManager;
        public HomeController(DataManager dataManager)
        {
            _dataManager = dataManager;
        }
        public IActionResult Index()
        {
            return View(_dataManager.StoreService.Store);
        }

        public IActionResult Add2Cart(Guid guid)
        {
            _dataManager.StoreService.AddToCart(guid);
            return RedirectToAction("Index", "Home");
        }
    }
}
