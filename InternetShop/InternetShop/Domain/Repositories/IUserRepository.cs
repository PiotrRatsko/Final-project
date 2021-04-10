using InternetShop.Domain.Entities;
using System;
using System.Collections.Generic;

namespace InternetShop.Domain.Repositories
{
    public interface IUserRepository
    {
        public User GetUserByEmail(string email);
        public User GetUserByEmailAndPassword(string email, string password);
        public void AddUser(User user);

        public Product GetProductById(Guid guid, string email);
        public void AddToCart(Product product, string email);
        public void PlusQuantity(Guid guid, string email);
        public void MinusQuantity(Guid guid, string email);
        public void RemoveProductFromCard(Guid guid, string email);
    }
}
