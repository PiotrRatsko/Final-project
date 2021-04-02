using InternetShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternetShop
{
    internal static class SampleData
    {
        public static void Initialize(ItemContext context)
        {
            if (!context.Motos.Any())
            {
                context.Motos.Add(new Moto() { Id = new Guid("bf5274b4-e9ec-41b5-b5d8-017306911f57"), Brand = "BMW", Name = "BMW1", Picter = "bmw_bmw1.jpg", Price = 123 });
                context.Motos.Add(new Moto() { Id = new Guid("a5b45769-e11a-4e3c-b4f5-8425e1d942cb"), Brand = "Honda", Name = "Honda1", Picter = "honda_honda1.jpg", Price = 99 });
                context.Motos.Add(new Moto() { Id = new Guid("0355ca00-14a7-4f76-a205-3b8a4789ddb7"), Brand = "Minsk", Name = "Minsk1", Picter = "minsk_minsk1.jpg", Price = 54 });
            }

            if (!context.Sushis.Any())
            {
                context.Sushis.Add(new Sushi() { Id = new Guid("6e0129e1-27bd-4f2c-8c0b-0696b9cc622a"), Brand = "Sushivesla", Name = "Chuka", Picter = "chuka_chuka1.jpg", Price = 2 });
                context.Sushis.Add(new Sushi() { Id = new Guid("81336f76-f597-48d8-b9a6-5fbfa1686bf6"), Brand = "Sushitime", Name = "Ika", Picter = "ika_ika1.jpg", Price = 3 });
                context.Sushis.Add(new Sushi() { Id = new Guid("0c02fb93-bf4c-45c3-a1d4-1dcb69e153b1"), Brand = "TokiNY", Name = "Tobica", Picter = "tobica_tobica1.jpg", Price = 4 });
            }
        }
    }
}
