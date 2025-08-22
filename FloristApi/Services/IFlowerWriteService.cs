using FloristApi.Models.Dtos.admin;
using FloristApi.Models.Dtos.@public;

namespace FloristApi.Services
{
    public interface IFlowerWriteService
    {
        Task<GetFlowerResponse> CreateFlower(CreateFlowerDto dto, CancellationToken ct);
        Task<bool?> UpdateFlower(int id, CreateFlowerDto dto, CancellationToken ct);
        Task<bool?> DeleteFlower(int id);
    }
}
