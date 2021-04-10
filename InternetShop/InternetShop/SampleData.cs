﻿using InternetShop.Domain.Entities;
using InternetShop.Domain.Repositories;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;

namespace InternetShop
{
    internal static class SampleData
    {
        public static List<Product> Initialize()
        {
            //List<Product> PRD = new List<Product>();
            //PRD.Add(new Product() { Name ="fff", Brand = "dd"});
            //PRD.Add(new Product() { Name = "fff", Brand = "dd" });
            //string jj = JsonConvert.SerializeObject(PRD);


            string content;
            try
            {
                using (StreamReader reader = File.OpenText(@"SampleData.json"))
                    content = reader.ReadToEnd();
                List<Product> deserializedProduct = JsonConvert.DeserializeObject<List<Product>>(content);

                foreach (var item in deserializedProduct)
                {
                    ValidateItem(item);
                }

                return deserializedProduct;
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