using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Text.Json.Serialization;

namespace API.Entities
{
    public class Review
    {
        [BsonElement("user")]
        [JsonPropertyName("user")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? User { get; set; }
    }
}
