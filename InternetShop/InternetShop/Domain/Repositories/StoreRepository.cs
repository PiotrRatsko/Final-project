using InternetShop.Constants;
using InternetShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InternetShop.Domain.Repositories
{
    public class StoreRepository : IStoreRepository
    {
        public Store Store { get; set; } = new Store();

        public User GetUser(string email)
        {
            return Store.Users.Where(i => i.Email.Equals(email, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
}
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

        public void AddToCart(Guid guid, string email)
        {
            Product prd = GetProductById(guid);
            if (!GetUser(email).Cart.CartItems.ContainsKey(prd))
            {
                GetUser(email)?.Cart.CartItems.Add(prd, 1);
            }
        }

        public void PlusQuantity(Guid guid, string email)
        {
            GetUser(email).Cart.CartItems[GetProductById(guid)]++;
        }

        public void MinusQuantity(Guid guid, string email)
        {
            if (GetUser(email)?.Cart.CartItems[GetProductById(guid)] != 1) GetUser(email).Cart.CartItems[GetProductById(guid)]--;
        }

        public void RemoveProductFromCard(Guid guid, string email)
        {
            GetUser(email)?.Cart.CartItems.Remove(GetProductById(guid));
        }
    }
}
