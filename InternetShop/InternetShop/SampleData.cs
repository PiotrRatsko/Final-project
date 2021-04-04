using InternetShop.Models;
using InternetShop.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace InternetShop
{
    internal static class SampleData
    {
        public static void Initialize(ProductService service)
        {
            //service.Products.Add(new Product { Brand = "4", Category = "45", Id = new Guid(), Name = "555", Picter = "55566", Price = 77 });
            //service.Products.Add(new Product { Brand = "18", Category = "77", Id = new Guid(), Name = "444", Picter = "44444", Price = 44 });
            //string kk = JsonSerializer.Serialize(service);

            Stream fs = null;
            try
            {
                fs = new FileStream("SampleData.json", FileMode.OpenOrCreate);
                ProductService obj = JsonSerializer.DeserializeAsync<ProductService>(fs).Result;

                foreach (var item in obj.Products)
                {
                    ValidateItem(item);
                }

                if (!service.Products.Any())
                {
                    service.Products = obj.Products;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Context was not initialized, {ex}");
            }
            finally
            {
                fs.Dispose();
            }

        }
        private static void ValidateItem(IProduct item)
        {
            var results = new List<ValidationResult>();
            var context = new ValidationContext(item);
            if (!Validator.TryValidateObject(item, context, results, true))
            {
                foreach (var error in results)
                {
                    throw new Exception(error.ErrorMessage);
                }
            }
        }
    }
}
