using API.Entities;
using API.Services;
using System.Text.Json;

namespace API.Data.Seeders
{
    public static class MongoDbDataSeeder
    {
        public static async Task SeedProduct(MongoDBService<Product> mongoDBService)
        {
            var products = await mongoDBService.GetAsync();
            if (products.Count == 0)
            {
                using (StreamReader streamReader
                    = new StreamReader("./MongoDbSeedData/products.json"))
                {
                    string json = streamReader.ReadToEnd();
                    var productsSeedList
                        = JsonSerializer.Deserialize<List<Product>?>(json);
                    if (productsSeedList != null)
                    {
                        await mongoDBService.CreateManyAsync(productsSeedList);
                    }
                }
            }
        }

        public static async Task SeedUser(MongoDBService<User> mongoDBService)
        {
            var users = await mongoDBService.GetAsync();
            if (users.Count == 0)
            {
                using (StreamReader streamReader
                    = new StreamReader("./MongoDbSeedData/users.json"))
                {
                    string json = streamReader.ReadToEnd();
                    var usersSeedList
                        = JsonSerializer.Deserialize<List<User>?>(json);
                    if (usersSeedList != null)
                    {
                        await mongoDBService.CreateManyAsync(usersSeedList);
                    }
                }
            }
        }
    }
}
