using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace API.Entities
{
    public class User
    {
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonElement("_id")]
        [JsonPropertyName("_id")]
        public string? Id { get; set; }

        [BsonElement("ts")]
        public BsonTimestamp? TimeStamp { get; set; }
            = new BsonTimestamp(DateTime.Now.Ticks);

        [BsonElement("name")]
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [BsonElement("email")]
        [JsonPropertyName("email")]
        public string? Email { get; set; }

        [BsonElement("password")]
        [JsonPropertyName("password")]
        public string? Password { get; set; }

        [BsonElement("isAdmin")]
        [JsonPropertyName("isAdmin")]
        public bool IsAdmin { get; set; }
    }
}
