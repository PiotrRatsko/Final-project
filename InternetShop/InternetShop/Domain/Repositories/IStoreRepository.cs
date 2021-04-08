using InternetShop.Domain.Entities;
using System;
using System.Collections.Generic;

namespace InternetShop.Domain.Repositories
{
    public interface IStoreRepository
    {
        public Store Store { get; set; }
        public Product GetProductById(Guid guid);
        public List<Product> GetFilteredProducts(string category, string price, string brand);
        public void AddToCart(Guid guid);
        public void PlusQuantity(Guid guid);
        public void MinusQuantity(Guid guid);
        public void RemoveProductFromCard(Guid guid);
    }
}
