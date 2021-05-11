using InternetShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InternetShop.Domain.Repositories
{
    public class UserRepository : IUserRepository
    {
        private static List<UserModel> Users { get; set; } = new List<UserModel>();
        public void AddUser(UserModel user)
        {
            Users.Add(user);
        }
        public UserModel GetUserByEmailAndPassword(string email, string password)
        {
            return Users.Where(i => i.Email.Equals(email, StringComparison.OrdinalIgnoreCase) && i.Password.Equals(password, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
        }

        public UserModel GetUserByEmail(string email)
        {
            return Users?.Where(i => i.Email.Equals(email, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
        }

        public void AddToCart(ProductModel product, string email)
        {
            if (!GetUserByEmail(email).Cart.CartItems.ContainsKey(product))
            {
                GetUserByEmail(email)?.Cart.CartItems.Add(product, 1);
            }
        }

        public void PlusQuantity(ProductModel product, string email)
        {
            GetUserByEmail(email).Cart.CartItems[product]++;
        }

        public void MinusQuantity(ProductModel product, string email)
        {
            if (GetUserByEmail(email)?.Cart.CartItems[product] != 1) GetUserByEmail(email).Cart.CartItems[product]--;
        }

        public void RemoveProductFromCard(ProductModel product, string email)
        {
            GetUserByEmail(email)?.Cart.CartItems.Remove(product);
        }
    }
}
