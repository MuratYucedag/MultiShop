using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.CategoryDtos;
using MultiShop.Catalog.Dtos.SpecialOfferDtos;
using MultiShop.Catalog.Entites;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.SpecialOfferServices
{
    public class SpecialOfferService : ISpecialOfferService
    {
        private readonly IMongoCollection<SpecialOffer> _specialOfferCollection;
        private readonly IMapper _mapper;
        public SpecialOfferService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _specialOfferCollection = database.GetCollection<SpecialOffer>(_databaseSettings.SpecialOfferCollectionName);
            _mapper = mapper;
        }
        public async Task CreateSpecialOfferAsync(CreateSpecialOfferDto createSpecialOfferDto)
        {
            var value = _mapper.Map<SpecialOffer>(createSpecialOfferDto);
            await _specialOfferCollection.InsertOneAsync(value);
        }

        public async Task DeleteSpecialOfferAsync(string id)
        {
            await _specialOfferCollection.DeleteOneAsync(x => x.SpecialOfferId == id);
        }

        public async Task<GetByIdSpecialOfferDto> GetByIdSpecialOfferAsync(string id)
        {
            var values = await _specialOfferCollection.Find<SpecialOffer>(x => x.SpecialOfferId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdSpecialOfferDto>(values);
        }

        public async Task<List<ResultSpecialOfferDto>> GettAllSpecialOfferAsync()
        {
            var values = await _specialOfferCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultSpecialOfferDto>>(values);
        }

        public async Task UpdateSpecialOfferAsync(UpdateSpecialOfferDto updateSpecialOfferDto)
        {
            var values = _mapper.Map<SpecialOffer>(updateSpecialOfferDto);
            await _specialOfferCollection.FindOneAndReplaceAsync(x => x.SpecialOfferId == updateSpecialOfferDto.SpecialOfferId, values);
        }
    }
}
