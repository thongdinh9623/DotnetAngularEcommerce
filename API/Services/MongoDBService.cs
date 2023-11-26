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

        public string CollectionName
        {
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

        public async Task<T> GetByIdAsync(string id)
        {
            var filter = new BsonDocument { { "_id", id } };
            var entity = await collection.Find(filter).SingleAsync();

            return entity;
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

        public async Task DeleteManyAsync()
        {
            if (collection != null)
            {
                _ = await collection.DeleteManyAsync(Builders<T>.Filter.Empty);
            }
        }
    }
}
