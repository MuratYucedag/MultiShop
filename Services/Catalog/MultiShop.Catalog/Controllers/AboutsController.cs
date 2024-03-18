using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.AboutDtos;
using MultiShop.Catalog.Services.AboutServices;

namespace MultiShop.Catalog.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AboutsController : ControllerBase
    {
        private readonly IAboutService _aboutService;
        public AboutsController(IAboutService AboutService)
        {
            _aboutService = AboutService;
        }

        [HttpGet]
        public async Task<IActionResult> AboutList()
        {
            var values = await _aboutService.GettAllAboutAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAboutById(string id)
        {
            var values = await _aboutService.GetByIdAboutAsync(id);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAbout(CreateAboutDto createAboutDto)
        {
            await _aboutService.CreateAboutAsync(createAboutDto);
            return Ok("Hakkımda alanı başarıyla eklendi");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAbout(string id)
        {
            await _aboutService.DeleteAboutAsync(id);
            return Ok("Hakkımda alanı başarıyla silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAbout(UpdateAboutDto updateAboutDto)
        {
            await _aboutService.UpdateAboutAsync(updateAboutDto);
            return Ok("Hakkımda alanı başarıyla güncellendi");
        }
    }
}
