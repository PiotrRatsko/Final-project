using InternetShop.Constants;
using InternetShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InternetShop.Domain.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private static List<ProductModel> Products { get; set; }
        public ProductRepository()
        {
            if (Products == null) Products = SampleData.Initialize();
        }

        public ProductModel GetProductById(Guid guid)
        {
            return Products.Where(prd => prd.Id.Equals(guid)).FirstOrDefault();
        }

        public List<ProductModel> GetFilteredProducts(string category, string price, string brand)
        {
            List<ProductModel> prod = Products.Select(i => i).ToList();

            if (!string.IsNullOrEmpty(category))
            {
                prod = Products.Where(prd => prd.Category.Equals(category, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            if (!string.IsNullOrEmpty(price))
            {
                switch (price)
                {
                    case Price.LowPrice: prod = prod.Where(prd => prd.Price <= 100).ToList(); break;
                    case Price.HighPrice: prod = prod.Where(prd => prd.Price > 100).ToList(); break;
                }
            }

            if (!string.IsNullOrEmpty(brand))
            {
                prod = prod.Where(prd => prd.Brand.Equals(brand, StringComparison.OrdinalIgnoreCase)).ToList();
            }
            return prod;
        }
    }
}
