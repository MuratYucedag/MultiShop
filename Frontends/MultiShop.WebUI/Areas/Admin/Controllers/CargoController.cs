using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CargoDtos.CargoCompanyDtos;
using MultiShop.WebUI.Services.CargoServices.CargoCompanyServices;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Cargo")]
    public class CargoController : Controller
    {
        private readonly ICargoCompanyService _cargoCompanyService;
        public CargoController(ICargoCompanyService cargoCompanyService)
        {
            _cargoCompanyService = cargoCompanyService;
        }

        [Route("CargoCompanyList")]
        public async Task<IActionResult> CargoCompanyList()
        {
            var values = await _cargoCompanyService.GetAllCargoCompanyAsync();
            return View(values);
        }

        [HttpGet]
        [Route("CreateCargoCompany")]
        public IActionResult CreateCargoCompany()
        {
            return View();
        }

        [HttpPost]
        [Route("CreateCargoCompany")]
        public async Task<IActionResult> CreateCargoCompany(CreateCargoCompanyDto createCargoCompanyDto)
        {
            await _cargoCompanyService.CreateCargoCompanyAsync(createCargoCompanyDto);
            return RedirectToAction("CargoCompanyList", "Cargo", new { Area = "Admin" });
        }


        [Route("DeleteCargoCompany/{id}")]
        public async Task<IActionResult> DeleteCargoCompany(int id)
        {
            await _cargoCompanyService.DeleteCargoCompanyAsync(id);
            return RedirectToAction("CargoCompanyList", "Cargo", new { Area = "Admin" });
        }

        [HttpGet]
        [Route("UpdateCargoCompany/{id}")]
        public async Task<IActionResult> UpdateCargoCompany(int id)
        {
            var values = await _cargoCompanyService.GetByIdCargoCompanyAsync(id);
            return View(values);
        }
        [HttpPost]
        [Route("UpdateCargoCompany")]
        public async Task<IActionResult> UpdateCargoCompany(UpdateCargoCompanyDto updateCargoCompanyDto)
        {
            await _cargoCompanyService.UpdateCargoCompanyAsync(updateCargoCompanyDto);
            return RedirectToAction("CargoCompanyList", "Cargo", new { Area = "Admin" });
        }
    }
}
