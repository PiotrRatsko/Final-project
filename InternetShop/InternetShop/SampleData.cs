﻿using InternetShop.Domain.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;

namespace InternetShop
{
    internal static class SampleData
    {
        public static void Initialize(Store store)
        {
            string content;
            try
            {
                using (StreamReader reader = File.OpenText(@"SampleData.json"))
                    content = reader.ReadToEnd();
                Store deserializedProduct = JsonConvert.DeserializeObject<Store>(content);

                foreach (var item in deserializedProduct.Products)
                {
                    ValidateItem(item);
                }

               store.Products = deserializedProduct.Products.Select(i => i).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"Context was not initialized, {ex}");
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
