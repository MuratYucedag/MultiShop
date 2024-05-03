using MultiShop.DtoLayer.IdentityDtos.UserDtos;

namespace MultiShop.WebUI.Services.UserIdentityServices
{
    public interface IUserIdentityService
    {
        Task<List<ResultUserDto>> GetAllUserListAsync();
    }
}
