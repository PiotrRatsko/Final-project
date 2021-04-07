using InternetShop.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternetShop.Domain
{
    public class DataManager
    {
        public IStoreServiceRepository StoreService { get; set; }

        public DataManager(IStoreServiceRepository storeService)
        {
            StoreService = storeService;
        }
    }
}
