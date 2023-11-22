using API.Entities;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace API.Services
{
    public class MongoDBService
    {

        private readonly IMongoCollection<Product> _productsCollection;

        public MongoDBService(IOptions<MongoDBSettings> mongoDBSettings)
        {
            MongoClient client = new(mongoDBSettings.Value.ConnectionURI);
            IMongoDatabase database
                = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
            _productsCollection
                = database.GetCollection<Product>("products");
        }

        public async Task<List<Product>> GetAsync()
        {
            return await _productsCollection
                .Find(new BsonDocument()).ToListAsync();
        }
    }
}
