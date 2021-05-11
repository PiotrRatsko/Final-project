using InternetShop.Domain.Entities;
using System;
using System.Collections.Generic;

namespace InternetShop.Domain.Repositories
{
    public interface IProductRepository
    {
        public ProductModel GetProductById(Guid guid);
        public List<ProductModel> GetFilteredProducts(string category, string price, string brand);
    }
}
