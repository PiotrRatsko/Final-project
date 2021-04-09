using System.Collections.Generic;

namespace InternetShop.Domain.Entities
{
    public class Store
    {
        public List<Product> Products { get; set; } = new List<Product>();
        
        public List<User> Users = new List<User>();
    }
}
