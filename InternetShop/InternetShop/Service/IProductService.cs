using InternetShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InternetShop.Service
{
    public interface IProductService
    {
        public List<Product> Products { get; set; }

        public IProduct GetProductById(Guid guid);
    }
}
