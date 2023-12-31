namespace API.Data
{
    public interface IMongoDbService<T>
    {
        Task<List<T>> GetAsync();

        Task<T> GetByIdAsync(string id);

        Task CreateAsync(T entity);

        Task CreateManyAsync(List<T> entities);

        Task DeleteManyAsync();
    }
}
