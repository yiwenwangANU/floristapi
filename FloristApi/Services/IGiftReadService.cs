using FloristApi.Models.Dtos.@public;
using FloristApi.Models.Entities;

namespace FloristApi.Services
{
    public interface IGiftReadService<T> where T : class , IGiftEntity
    {
        Task<IEnumerable<GetGiftResponse>> GetAllGifts(CancellationToken ct = default);
        Task<GetGiftResponse?> GetGiftById(int id, CancellationToken ct = default);
    }

}
