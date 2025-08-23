namespace FloristApi.Repositories
{
    public interface IGiftRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll(CancellationToken ct);
        Task<T?> GetById(int id, CancellationToken ct);
        Task Add(T entity, CancellationToken ct);
        Task Update(T entity, CancellationToken ct);
        Task<bool> Delete(int id, CancellationToken ct);
    }
}
