using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MultiShop.Catalog.Entites
{
    public class OfferDiscount
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string OfferDiscountId { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string ImageUrl { get; set; }
        public string ButtonTitle { get; set; }
    }
}
