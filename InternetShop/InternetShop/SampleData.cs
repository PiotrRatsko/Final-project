using InternetShop.Models;
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
        public static void Initialize(ItemContext context)
        {
            Stream fs = null;
            try
            {
                fs = new FileStream("SampleData.json", FileMode.OpenOrCreate);
                ItemContext obj = JsonSerializer.DeserializeAsync<ItemContext>(fs).Result;

                foreach (var item in obj.Motos)
                {
                    ValidateItem(item);
                }

                foreach (var item in obj.Sushis)
                {
                    ValidateItem(item);
                }

                if (!context.Motos.Any())
                {
                    context.Motos = obj.Motos;
                }

                if (!context.Sushis.Any())
                {
                    context.Sushis = obj.Sushis;
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
        private static void ValidateItem(IItem item)
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
