using FloristApi.Models.Dtos.admin;
using FloristApi.Models.Dtos.@public;

namespace FloristApi.Services
{
    public interface IPlantWriteService
    {
        Task<GetPlantResponse> CreatePlant(CreatePlantDto dto, CancellationToken ct = default);
        Task<bool?> UpdatePlant(int id, CreatePlantDto dto, CancellationToken ct = default);
        Task DeletePlant(int id, CancellationToken ct = default);
    }
}
