using MultiShop.DtoLayer.IdentityDtos.LoginDtos;

namespace MultiShop.WebUI.Services.Interfaces
{
    public interface IIdentityService
    {
        Task<bool> SignIn(SignInDto signInDto);
    }
}
