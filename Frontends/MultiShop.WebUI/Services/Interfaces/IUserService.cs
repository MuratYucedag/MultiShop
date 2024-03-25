using MultiShop.WebUI.Models;

namespace MultiShop.WebUI.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserDetailViewModel> GetUserInfo();
    }
}
