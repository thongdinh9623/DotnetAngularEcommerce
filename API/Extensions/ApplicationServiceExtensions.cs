using API.Entities;
using API.Services;

namespace API.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(
            this IServiceCollection services,
            IConfiguration config)
        {
            _ = services.Configure<MongoDBSettings>(config.GetSection("MongoDB"));
            _ = services.AddSingleton<MongoDBService<Product>>();
            _ = services.AddSingleton<MongoDBService<User>>();

            return services;
        }
    }
}