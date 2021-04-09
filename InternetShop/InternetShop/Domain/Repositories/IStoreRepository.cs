using InternetShop.Domain.Entities;
using System;
using System.Collections.Generic;

namespace InternetShop.Domain.Repositories
{
    public interface IStoreRepository
    {
        //public Store Store { get; set; }
        public User GetUserByEmail(string email);
        public User GetUserByEmailAndPassword(string email, string password);
        public void AddUser(User user);
        public Product GetProductById(Guid guid);
        public List<Product> GetFilteredProducts(string category, string price, string brand);
        public void AddToCart(Guid guid, string email);
        public void PlusQuantity(Guid guid, string email);
        public void MinusQuantity(Guid guid, string email);
        public void RemoveProductFromCard(Guid guid, string email);
    }
}
