using FloristApi.Models.Dtos.@public;

namespace FloristApi.Services
{
    public interface IPlantReadService
    {
        Task<IEnumerable<GetPlantResponse>> GetPlants(GetPlantDto dto, CancellationToken ct = default);
        Task<GetPlantResponse> GetPlantById(int id, CancellationToken ct = default);
    }
}
