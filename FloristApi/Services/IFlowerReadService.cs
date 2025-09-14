using FloristApi.Models.Dtos.@public;

namespace FloristApi.Services
{
    public interface IFlowerReadService
    {
        Task<IEnumerable<GetFlowerResponse>> GetFlowers(GetFlowerDto dto, CancellationToken ct = default);
        Task<GetFlowerResponse> GetFlowerById(int id, CancellationToken ct = default);
    }
}
