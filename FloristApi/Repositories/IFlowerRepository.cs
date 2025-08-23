using FloristApi.Models.Entities;

namespace FloristApi.Repositories
{
    public interface IFlowerRepository
    {
        Task<IEnumerable<Flower>> GetAll(CancellationToken ct);
        Task<Flower?> GetById(int id, CancellationToken ct);
        Task Add(Flower entity, CancellationToken ct);
        Task Update(Flower entity, CancellationToken ct);
        Task<bool> Delete(int id, CancellationToken ct);
    }
}
