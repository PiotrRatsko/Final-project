﻿using InternetShop.Constants;
using InternetShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InternetShop.Service
{
    public class StoreService
    {
        public Store Store { get; set; } = new Store();

        public Product GetProductById(Guid guid)
        {
            return Store.Products.Where(prd => prd.Id.Equals(guid)).FirstOrDefault();
        }

        public List<Product> GetFilteredProducts(string category, string price, string brand)
        {
            List<Product> prod = Store.Products.Select(i => i).ToList();

            if (!string.IsNullOrEmpty(category))
            {
                prod = Store.Products.Where(prd => prd.Category.Equals(category, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            if (!string.IsNullOrEmpty(price))
            {
                switch (price)
                {
                    case Price.LowPrice: prod = prod.Where(prd => prd.Price <= 100).ToList(); break;
                    case Price.HighPrice: prod = prod.Where(prd => prd.Price > 100).ToList(); break;
                }
            }

            if (!string.IsNullOrEmpty(brand))
            {
                prod = prod.Where(prd => prd.Brand.Equals(brand, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            return prod;
        }

        public void AddToCart(Guid guid)
        {
            Product prd = GetProductById(guid);
            if (!Store.Cart.CartItems.ContainsKey(prd))
            {
                Store.Cart.CartItems.Add(prd, 1);
            }
        }
    }
}
