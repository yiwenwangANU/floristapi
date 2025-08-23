using FloristApi.Models.Dtos.admin;
using FloristApi.Models.Dtos.@public;
using FloristApi.Models.Entities;

namespace FloristApi.Services
{
    public interface IGiftWriteService<T> where T : class, IGiftEntity
    {
        Task<GetGiftResponse> CreateGift(CreateGiftDto dto, CancellationToken ct);
        Task<bool?> UpdateGift(int id, CreateGiftDto dto, CancellationToken ct);
        Task DeleteGift(int id);
    }
}
