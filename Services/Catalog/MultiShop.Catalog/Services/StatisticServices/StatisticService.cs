using MongoDB.Driver;
using MultiShop.Catalog.Entites;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.StatisticServices
{
    public class StatisticService : IStatisticService
    {
        private readonly IMongoCollection<Product> _productCollection;
        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly IMongoCollection<Brand> _brandCollection;

        public StatisticService(IMongoCollection<Product> productCollection, IMongoCollection<Category> categoryCollection, IMongoCollection<Brand> brandCollection, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _productCollection = database.GetCollection<Product>(_databaseSettings.ProductCollectionName);
            _categoryCollection = database.GetCollection<Category>(_databaseSettings.CategoryCollectionName);
            _brandCollection = database.GetCollection<Brand>(_databaseSettings.BrandCollectionName);
        }

        public int GetBrandCount()
        {
            throw new NotImplementedException();
        }

        public int GetCategoryCount()
        {
            throw new NotImplementedException();
        }

        public decimal GetProductAvgPrice()
        {
            throw new NotImplementedException();
        }

        public int GetProductCount()
        {
            throw new NotImplementedException();
        }
    }
}
