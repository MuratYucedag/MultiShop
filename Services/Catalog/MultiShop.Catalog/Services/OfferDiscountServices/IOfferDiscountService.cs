using MultiShop.Catalog.Dtos.OfferDiscountDtos;

namespace MultiShop.Catalog.Services.OfferDiscountServices
{
    public interface IOfferDiscountService
    {
        Task<List<ResultOfferDiscountDto>> GettAllOfferDiscountAsync();
        Task CreateOfferDiscountAsync(CreateOfferDiscountDto createOfferDiscountDto);
        Task UpdateOfferDiscountAsync(UpdateOfferDiscountDto updateOfferDiscountDto);
        Task DeleteOfferDiscountAsync(string id);
        Task<GetByIdOfferDiscountDto> GetByIdOfferDiscountAsync(string id);
    }
}
