using API.Entities;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace API.Services
{
    public class MongoDBService<T>
    {
        private readonly IMongoDatabase? _database;
        private IMongoCollection<T>? collection;
        private readonly string? collectionName;

        public string CollectionName
        {
            get => collectionName;
            set => collection = _database.GetCollection<T>(value);
        }

        public MongoDBService(IOptions<MongoDBSettings> mongoDBSettings)
        {
            MongoClient client = new(mongoDBSettings.Value.ConnectionURI);
            _database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);

        }

        public async Task<List<T>> GetAsync()
        {
            return await collection.Find(new BsonDocument()).ToListAsync();
        }

        public async Task CreateAsync(T entity)
        {
            if (collection != null)
            {
                await collection.InsertOneAsync(entity);
            }
        }

        public async Task CreateManyAsync(List<T> entities)
        {
            if (collection != null)
            {
                await collection.InsertManyAsync(entities);
            }
        }
    }
}
