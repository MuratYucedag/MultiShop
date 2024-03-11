using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MultiShop.Catalog.Entites
{
    public class Feature
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string FeatureId { get; set; }
        public string Title { get; set; }
        public string Icon { get; set; }
    }
}
