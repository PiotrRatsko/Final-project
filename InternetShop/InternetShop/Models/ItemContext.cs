﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace InternetShop.Models
{
    public class ItemContext
    {
        public List<Moto> Motos { get; set; } = new List<Moto>();
        public List<Sushi> Sushis { get; set; } = new List<Sushi>();

        public IItem GetProductById(Guid guid)
        {
            return Motos.Where(moto => moto.Id.Equals(guid)).FirstOrDefault();
        }
    }
}
