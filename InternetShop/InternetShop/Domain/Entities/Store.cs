using InternetShop.Models;
using System.Collections.Generic;

namespace InternetShop.Domain.Entities
{
    public class Store
    {
        public List<Product> Products { get; set; } = new List<Product>();
        public Cart Cart { get; set; } = new Cart();
        public List<User> Users = new List<User>();
        public RegisterModel registerModel = new RegisterModel();
        public LoginModel loginModel = new LoginModel();
    }
}
