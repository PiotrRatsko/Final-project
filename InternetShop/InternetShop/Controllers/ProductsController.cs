﻿using InternetShop.Service;
using InternetShop.Service.Constants;
using Microsoft.AspNetCore.Mvc;

namespace InternetShop.Controllers
{
    public class ProductsController : Controller
    {
        readonly ProductService _service;
        public ProductsController(ProductService service)
        {
            _service = service;
        }
        public IActionResult Index(string category, string price)
        {
            if (!string.IsNullOrEmpty(category) || !string.IsNullOrEmpty(price))
            {
                ViewBag.Products = _service.GetFilteredProducts(category, price);
            }
            else
            {
                ViewBag.Products = _service.Products;

            }
            ViewData["Category"] = string.IsNullOrEmpty(category) ? Category.AllCategories : category;
            ViewData["Price"] = string.IsNullOrEmpty(price) ? Price.AllPrices : price;

            return View(_service);
        }
    }
}
