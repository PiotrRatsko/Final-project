using InternetShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InternetShop.Domain.Repositories
{
    public class UserRepository : IUserRepository
    {
        private static List<User> Users { get; set; } = new List<User>();
        public void AddUser(User user)
        {
            Users.Add(user);
        }
        public User GetUserByEmailAndPassword(string email, string password)
        {
            return Users.Where(i => i.Email.Equals(email, StringComparison.OrdinalIgnoreCase) && i.Password.Equals(password, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
        }

        public User GetUserByEmail(string email)
        {
            return Users?.Where(i => i.Email.Equals(email, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
        }

        public void AddToCart(Product product, string email)
        {
            if (!GetUserByEmail(email).Cart.CartItems.ContainsKey(product))
            {
                GetUserByEmail(email)?.Cart.CartItems.Add(product, 1);
            }
        }

        public void PlusQuantity(Product product, string email)
        {
            GetUserByEmail(email).Cart.CartItems[product]++;
        }

        public void MinusQuantity(Product product, string email)
        {
            if (GetUserByEmail(email)?.Cart.CartItems[product] != 1) GetUserByEmail(email).Cart.CartItems[product]--;
        }

        public void RemoveProductFromCard(Product product, string email)
        {
            GetUserByEmail(email)?.Cart.CartItems.Remove(product);
        }
    }
}
