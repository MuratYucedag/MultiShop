namespace MultiShop.Catalog.Services.StatisticServices
{
    public interface IStatisticService
    {
        int GetCategoryCount();
        int GetProductCount();
        long GetBrandCount();
        decimal GetProductAvgPrice();
    }
}
