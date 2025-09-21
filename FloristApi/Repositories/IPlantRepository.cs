using FloristApi.Models.Dtos.@public;
using FloristApi.Models.Entities;

namespace FloristApi.Repositories
{
    public interface IPlantRepository
    {
        Task<IEnumerable<Plant>> GetAll(CancellationToken ct = default);
        Task<IEnumerable<Plant>> GetPlant(GetPlantQuery query, CancellationToken ct = default);
        Task<Plant?> GetById(int id, CancellationToken ct = default);
        Task Add(Plant entity, CancellationToken ct = default);
        Task Update(Plant entity, CancellationToken ct = default);
        Task<bool> Delete(int id, CancellationToken ct = default);
    }
}
