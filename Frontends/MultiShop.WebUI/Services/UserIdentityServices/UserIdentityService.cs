using MultiShop.DtoLayer.IdentityDtos.UserDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Services.UserIdentityServices
{
    public class UserIdentityService : IUserIdentityService
    {
        private readonly HttpClient _httpClient;
        public UserIdentityService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<ResultUserDto>> GetAllUserListAsync()
        {
            var responseMessage = await _httpClient.GetAsync("http://localhost:5001/api/users/GetAllUserList");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultUserDto>>(jsonData);
            return values;
        }
    }
}
