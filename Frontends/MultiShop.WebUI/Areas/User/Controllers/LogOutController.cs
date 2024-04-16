using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.Areas.User.Controllers
{
    public class LogOutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
