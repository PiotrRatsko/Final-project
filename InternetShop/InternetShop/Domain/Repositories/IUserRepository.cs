using InternetShop.Domain.Entities;

namespace InternetShop.Domain.Repositories
{
    public interface IUserRepository
    {
        public UserModel GetUserByEmail(string email);
        public UserModel GetUserByEmailAndPassword(string email, string password);
        public void AddUser(UserModel user);
        public void AddToCart(ProductModel product, string email);
        public void PlusQuantity(ProductModel product, string email);
        public void MinusQuantity(ProductModel product, string email);
        public void RemoveProductFromCard(ProductModel product, string email);
    }
}
