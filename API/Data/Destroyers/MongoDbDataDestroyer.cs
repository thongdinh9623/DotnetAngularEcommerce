using API.Entities;

namespace API.Data.Destroyers
{
    public static class MongoDbDataDestroyer
    {
        public static async Task DestroyProduct(MongoDbService<Product> mongoDBService)
        {
            await mongoDBService.DeleteManyAsync();
        }

        public static async Task DestroyUser(MongoDbService<User> mongoDBService)
        {
            await mongoDBService.DeleteManyAsync();
        }
    }
}
