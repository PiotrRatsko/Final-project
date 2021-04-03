using Microsoft.AspNetCore.Mvc;

namespace InternetShop.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
