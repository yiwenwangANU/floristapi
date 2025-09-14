using FloristApi.Models.Dtos.@public;
using FloristApi.Models.Entities;

namespace FloristApi.Repositories
{
    public interface IFlowerRepository
    {
        Task<IEnumerable<Flower>> GetAll(CancellationToken ct = default);
        Task<IEnumerable<Flower>> GetFlower(GetFlowerQuery query, CancellationToken ct = default);
        Task<Flower?> GetById(int id, CancellationToken ct = default);
        Task Add(Flower entity, CancellationToken ct = default);
        Task Update(Flower entity, CancellationToken ct = default);
        Task<bool> Delete(int id, CancellationToken ct = default);
    }
}
