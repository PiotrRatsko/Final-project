using InternetShop.Constants;
using InternetShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InternetShop.Service
{
    public class StoreService
    {
        public List<Product> Products { get; set; } = new List<Product>();
        public Cart Cart { get; set; } = new Cart();

        public Product GetProductById(Guid guid)
        {
            return Products.Where(prd => prd.Id.Equals(guid)).FirstOrDefault();
        }

        public List<Product> GetFilteredProducts(string category, string price, string brand)
        {
            List<Product> prod = Products.Select(i => i).ToList();

            if (!string.IsNullOrEmpty(category))
            {
                prod = Products.Where(prd => prd.Category.Equals(category, StringComparison.OrdinalIgnoreCase)).ToList();
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
            if (!Cart.CartItems.ContainsKey(prd))
            {
                Cart.CartItems.Add(prd, 1);
            }
        }
    }
}
