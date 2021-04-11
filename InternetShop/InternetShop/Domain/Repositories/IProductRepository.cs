using InternetShop.Domain.Entities;
using System;
using System.Collections.Generic;

namespace InternetShop.Domain.Repositories
{
    public interface IProductRepository
    {
        public Product GetProductById(Guid guid);
        public List<Product> GetFilteredProducts(string category, string price, string brand);
    }
}
