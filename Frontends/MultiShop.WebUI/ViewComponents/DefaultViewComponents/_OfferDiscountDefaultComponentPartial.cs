using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.OfferDiscountDtos;
using MultiShop.WebUI.Services.CatalogServices.OfferDiscountServices;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents.DefaultViewComponents
{
    public class _OfferDiscountDefaultComponentPartial : ViewComponent
    {
        private readonly IOfferDiscountService _offerDiscountService;
        public _OfferDiscountDefaultComponentPartial(IOfferDiscountService offerDiscountService)
        {
            _offerDiscountService = offerDiscountService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _offerDiscountService.GetAllOfferDiscountAsync();
            return View(values);
        }
    }
}
