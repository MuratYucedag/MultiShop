namespace MultiShop.WebUI.Services.Interfaces
{
    public interface IClientCredentialTokenService
    {
        Task<string> GetToken();
    }
}
