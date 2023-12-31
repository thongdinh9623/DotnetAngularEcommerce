using API.Data;
using API.Entities;

namespace API.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(
            this IServiceCollection services,
            IConfiguration config)
        {
            _ = services.Configure<MongoDBSettings>(config.GetSection("MongoDB"));
            _ = services.AddSingleton<IMongoDbService<User>, MongoDbService<User>>();
            _ = services.AddSingleton<IMongoDbService<Product>, MongoDbService<Product>>();

            return services;
        }
    }
}
