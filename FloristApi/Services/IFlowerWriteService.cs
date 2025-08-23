using FloristApi.Models.Dtos.admin;
using FloristApi.Models.Dtos.@public;
using FloristApi.Models.Entities;

namespace FloristApi.Services
{
    public interface IFlowerWriteService
    {
        Task<IEnumerable<Flower>> GetFlowersAdmin(CancellationToken ct = default);
        Task<GetFlowerResponse> CreateFlower(CreateFlowerDto dto, CancellationToken ct = default);
        Task<bool?> UpdateFlower(int id, CreateFlowerDto dto, CancellationToken ct = default);
        Task DeleteFlower(int id, CancellationToken ct = default);
    }
}
