using InternetShop.Domain.Repositories;

namespace InternetShop.Domain
{
    public class DataManager
    {
        public IStoreRepository Repository { get; set; }


        public DataManager(IStoreRepository repo)
        {
            Repository = repo;
        }
    }
}