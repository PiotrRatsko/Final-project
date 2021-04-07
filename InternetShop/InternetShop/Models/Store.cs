using InternetShop.Domain.Entities;
using System.Collections.Generic;

namespace InternetShop.Models
{
    public class Store
    {
        public List<Product> Products { get; set; } = new List<Product>();
        public Cart Cart { get; set; } = new Cart();
    }
}
