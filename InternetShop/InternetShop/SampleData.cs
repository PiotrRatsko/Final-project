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
        public static void Initialize(Store store)
        {
            Stream fs = null;
            try
            {
                fs = new FileStream("SampleData.json", FileMode.OpenOrCreate);
                Store obj = JsonSerializer.DeserializeAsync<Store>(fs).Result;

                foreach (var item in obj.Products)
                {
                    ValidateItem(item);
                }

                if (!store.Products.Any())
                {
                    store.Products = obj.Products;
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
        private static void ValidateItem(Product item)
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
