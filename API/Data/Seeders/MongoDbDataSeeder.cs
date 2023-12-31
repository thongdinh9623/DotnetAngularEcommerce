using API.Entities;
using System.Text.Json;

namespace API.Data.Seeders
{
    public static class MongoDbDataSeeder
    {
        const string SeederPath = "./Data/Seeders/MongoDbSeedData";

        public static async Task Seed(
            MongoDbService<Product> mongoDbProductService,
            MongoDbService<User> mongoDbUserService)
        {
            await SeedUser(mongoDbProductService, mongoDbUserService);
        }

        public static async Task SeedProduct(
            MongoDbService<Product> mongoDBService,
            string adminUserId)
        {
            var products = await mongoDBService.GetAsync();
            if (products.Count == 0)
            {
                using (StreamReader streamReader
                    = new StreamReader(Path.Combine(SeederPath, "products.json")))
                {
                    string json = streamReader.ReadToEnd();
                    var productsSeedList
                        = JsonSerializer.Deserialize<List<Product>?>(json);
                    if (productsSeedList != null)
                    {
                        foreach (var product in productsSeedList)
                        {
                            product.User = adminUserId;
                        }
                        await mongoDBService.CreateManyAsync(productsSeedList);
                    }
                }
            }
        }

        public static async Task SeedUser(
            MongoDbService<Product> mongoDbProductService,
            MongoDbService<User> mongoDbUserService)
        {
            var users = await mongoDbUserService.GetAsync();
            if (users.Count == 0)
            {
                using (StreamReader streamReader
                    = new StreamReader(Path.Combine(SeederPath, "users.json")))
                {
                    string json = streamReader.ReadToEnd();
                    var usersSeedList
                        = JsonSerializer.Deserialize<List<User>?>(json);
                    if (usersSeedList != null)
                    {
                        await mongoDbUserService.CreateManyAsync(usersSeedList);
                        users = await mongoDbUserService.GetAsync();
                        var adminUserId
                            = users.Where(u => u.IsAdmin).FirstOrDefault().Id;
                        await SeedProduct(mongoDbProductService, adminUserId);
                    }
                }
            }
        }
    }
}
