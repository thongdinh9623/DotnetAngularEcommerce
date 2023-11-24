using API.Entities;
using API.Services;

namespace API.Data.Destroyers
{
    public static class MongoDbDataDestroyer
    {
        public static async Task DestroyProduct(MongoDBService<Product> mongoDBService)
        {
            await mongoDBService.DeleteManyAsync();
        }

        public static async Task DestroyUser(MongoDBService<User> mongoDBService)
        {
            await mongoDBService.DeleteManyAsync();
        }
    }
}
