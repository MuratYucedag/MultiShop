using MultiShop.Catalog.Dtos.SpecialOfferDtos;

namespace MultiShop.Catalog.Services.SpecialOfferServices
{
    public interface ISpecialOfferService
    {
        Task<List<ResultSpecialOfferDto>> GettAllSpecialOfferAsync();
        Task CreateSpecialOfferAsync(CreateSpecialOfferDto createSpecialOfferDto);
        Task UpdateSpecialOfferAsync(UpdateSpecialOfferDto updateSpecialOfferDto);
        Task DeleteSpecialOfferAsync(string id);
        Task<GetByIdSpecialOfferDto> GetByIdSpecialOfferAsync(string id);
    }
}
