using InternetShop.Domain;
using InternetShop.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace InternetShop.Controllers
{
    public class ContactController : Controller
    {
        readonly DataManager _dataManager;
        public ContactController(DataManager dataManager)
        {
            _dataManager = dataManager;
        }
        public IActionResult Index()
        {
            ViewBag.TotalQuantity = _dataManager.StoreRepository.GetUser(User.Identity.Name)?.Cart.TotalQuantity;
            return View();
        }
    }
}
