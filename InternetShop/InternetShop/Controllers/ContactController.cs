using InternetShop.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace InternetShop.Controllers
{
    public class ContactController : Controller
    {
        readonly IStoreRepository _repo;
        public ContactController(IStoreRepository repo)
        {
            _repo = repo;
        }
        public IActionResult Index()
        {
            ViewBag.TotalQuantity = _repo.GetUserByEmail(User.Identity.Name)?.Cart.TotalQuantity;
            return View();
        }
    }
}
