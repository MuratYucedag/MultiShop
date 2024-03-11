using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MultiShop.Catalog.Entites
{
    public class Category
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string ImageUrl { get; set; }
    }
}
