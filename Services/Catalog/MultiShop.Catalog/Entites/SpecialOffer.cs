using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MultiShop.Catalog.Entites
{
    public class SpecialOffer
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string SpecialOfferId { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string ImageUrl { get; set; }
    }
}
