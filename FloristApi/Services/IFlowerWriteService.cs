using FloristApi.Models.Dtos.admin;
using FloristApi.Models.Dtos.@public;
using FloristApi.Models.Entities;

namespace FloristApi.Services
{
    public interface IFlowerWriteService
    {
        Task<IEnumerable<Flower>> GetFlowersAdmin();
        Task<GetFlowerResponse> CreateFlower(CreateFlowerDto dto, CancellationToken ct);
        Task<bool?> UpdateFlower(int id, CreateFlowerDto dto, CancellationToken ct);
        Task<bool?> DeleteFlower(int id);
    }
}
