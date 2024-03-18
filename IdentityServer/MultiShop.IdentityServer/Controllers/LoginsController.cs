using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MultiShop.IdentityServer.Dtos;
using MultiShop.IdentityServer.Models;
using MultiShop.IdentityServer.Tools;
using System.Threading.Tasks;

namespace MultiShop.IdentityServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginsController : ControllerBase
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public LoginsController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> UserLogin(UserLoginDto userLoginDto)
        {
            var result = await _signInManager.PasswordSignInAsync(userLoginDto.Username, userLoginDto.Password, false, false);
            var user = await _userManager.FindByNameAsync(userLoginDto.Username);

            if (result.Succeeded)
            {
                GetCheckAppUserViewModel model = new GetCheckAppUserViewModel();
                model.Username = userLoginDto.Username;
                model.Id = user.Id;
                var token = JwtTokenGenerator.GenerateToken(model);
                return Ok(token);
            }
            else
            {
                return Ok("Kullanıcı Adı veya Şifre Hatalı");
            }
        }
    }
}
