using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MultiShop.IdentityServer.Models;
using System.Linq;
using System.Threading.Tasks;

namespace MultiShop.IdentityServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public StatisticsController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult GetUserCount()
        {
            int usercount = _userManager.Users.Count();
            return Ok(usercount);
        }
    }
}
