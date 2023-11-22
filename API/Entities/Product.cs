using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace API.Entities
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("name")]
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [BsonElement("description")]
        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [BsonElement("category")]
        [JsonPropertyName("category")]
        public string? Category { get; set; }

        [BsonElement("author")]
        [JsonPropertyName("author")]
        public string? Author { get; set; }

        [BsonElement("image")]
        [JsonPropertyName("image")]
        public string? Image { get; set; }

        [BsonElement("price")]
        [JsonPropertyName("price")]
        public decimal Price { get; set; }

        [BsonElement("countInStock")]
        [JsonPropertyName("countInStock")]
        public int CountInStock { get; set; }

        [BsonElement("rating")]
        [JsonPropertyName("rating")]
        public decimal Rating { get; set; }

        [BsonElement("numReviews")]
        [JsonPropertyName("numReviews")]
        public int NumReviews { get; set; }

        [BsonElement("user")]
        [JsonPropertyName("user")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? User { get; set; }

        [BsonElement("ts")]
        public BsonTimestamp? TimeStamp { get; set; }
    }
}
