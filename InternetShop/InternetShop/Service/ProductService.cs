using InternetShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InternetShop.Service
{
    public class ProductService
    {
        public List<Product> Products { get; set; } = new List<Product>();

        public Product GetProductById(Guid guid)
        {
            return Products.Where(prd => prd.Id.Equals(guid)).FirstOrDefault();
        }

        public List<Product> GetProductByCategory(string category)
        {
            return Products.Where(prd => prd.Category.Equals(category,StringComparison.OrdinalIgnoreCase)).ToList();
        }
    }
}
