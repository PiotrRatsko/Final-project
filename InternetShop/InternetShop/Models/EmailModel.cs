using System.ComponentModel.DataAnnotations;

namespace InternetShop.Models
{
    public class EmailModel
    {
        [Required(ErrorMessage = "Please add Email")]
        [EmailAddress(ErrorMessage = "Email is not valid")]
        public string Email { get; set; }
        public string Name { get; set; }
        [Required(ErrorMessage = "Please add subject")]
        public string Subject { get; set; }
        [Required(ErrorMessage = "Please add message")]
        public string Message { get; set; }
    }
}