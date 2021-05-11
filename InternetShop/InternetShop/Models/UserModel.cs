namespace InternetShop.Domain.Entities
{
    public class UserModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public CartModel Cart { get; set; } = new CartModel();
    }
}
