using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.Areas.User.Controllers
{
    public class CargoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
