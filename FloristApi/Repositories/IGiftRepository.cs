namespace FloristApi.Repositories
{
    public interface IGiftRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll(CancellationToken ct = default);
        Task<T?> GetById(int id, CancellationToken ct = default);
        Task Add(T entity, CancellationToken ct = default);
        Task Update(T entity, CancellationToken ct = default);
        Task<bool> Delete(int id, CancellationToken ct = default);
    }
}
