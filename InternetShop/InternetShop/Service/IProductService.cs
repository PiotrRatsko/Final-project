using InternetShop.Constants;
using InternetShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InternetShop.Service
{
    public interface IProductService
    {
        public List<Product> Products { get; set; }

        public Product GetProductById(Guid guid);

        public List<Product> GetFilteredProducts(string category, string price, string brand);
    }
}
