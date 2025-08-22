using FloristApi.Models.Dtos.admin;
using FloristApi.Models.Dtos.@public;

namespace FloristApi.Services
{
    public interface IFlowerWriteService
    {
        Task<GetFlowerResponse> CreateFlower(CreateFlowerDto dto, CancellationToken ct);
        Task<GetFlowerResponse> UpdateFlower(int id, CreateFlowerDto dto, CancellationToken ct);
        Task DeleteFlower(int id);
    }
}
