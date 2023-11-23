using API.Entities;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace API.Services
{
    public class MongoDBService<T>
    {
        protected readonly IMongoCollection<T>? _collection;

        public string? CollectionName { get; set; }

        public MongoDBService(IOptions<MongoDBSettings> mongoDBSettings)
        {
            MongoClient client = new(mongoDBSettings.Value.ConnectionURI);
            IMongoDatabase database
                = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
            _collection = database.GetCollection<T>(CollectionName);
        }

        public async Task<List<T>> GetAsync()
        {
            return await _collection.Find(new BsonDocument()).ToListAsync();
        }

        public async Task CreateAsync(T entity)
        {
            if (_collection != null)
            {
                await _collection.InsertOneAsync(entity);
            }
        }

        public async Task CreateManyAsync(List<T> entities)
        {
            if (_collection != null)
            {
                await _collection.InsertManyAsync(entities);
            }
        }
    }
}
