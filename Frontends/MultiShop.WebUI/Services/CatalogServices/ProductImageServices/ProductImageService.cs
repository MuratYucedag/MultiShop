using MultiShop.DtoLayer.CatalogDtos.ProductImageDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Services.CatalogServices.ProductImageServices
{
    public class ProductImageService:IProductImageService
    {
        private readonly HttpClient _httpClient;
        public ProductImageService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task CreateProductImageAsync(CreateProductImageDto createProductImageDto)
        {
            await _httpClient.PostAsJsonAsync<CreateProductImageDto>("productimages", createProductImageDto);
        }
        public async Task DeleteProductImageAsync(string id)
        {
            await _httpClient.DeleteAsync("productimages?id=" + id);
        }
        public async Task<GetByIdProductImageDto> GetByIdProductImageAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("productimages/" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<GetByIdProductImageDto>();
            return values;
        }
        public async Task<List<ResultProductImageDto>> GetAllProductImageAsync()
        {
            var responseMessage = await _httpClient.GetAsync("productimages");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultProductImageDto>>(jsonData);
            return values;
        }
        public async Task UpdateProductImageAsync(UpdateProductImageDto updateProductImageDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateProductImageDto>("productimages", updateProductImageDto);
        }

        public async Task<GetByIdProductImageDto> GetByProductIdProductImageAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("productimages/ProductImagesByProductId/" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<GetByIdProductImageDto>();
            return values;
        }

       
    }
}
