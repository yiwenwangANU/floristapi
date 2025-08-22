using FloristApi.Models.Dtos.@public;
using FloristApi.Models.Entities;

namespace FloristApi.Services
{
    public interface IGiftReadService<T> where T : class , IGiftEntity
    {
        Task<IEnumerable<GetGiftResponse>> GetAllGifts();
        Task<GetGiftResponse?> GetGiftById(int id);
    }

}
