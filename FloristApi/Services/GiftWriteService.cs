using FloristApi.Data;
using FloristApi.Models.Dtos.admin;
using FloristApi.Models.Dtos.@public;
using FloristApi.Models.Entities;
using FloristApi.Models.Mappings;
using FloristApi.Repositories;

namespace FloristApi.Services
{
    public class GiftWriteService<T> : IGiftWriteService<T> where T : class, IGiftEntity, new()
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IGiftRepository<T> _giftRepository;
        public GiftWriteService(ApplicationDbContext dbContext, IGiftRepository<T> giftRepository)
        {
            _dbContext = dbContext;
            _giftRepository = giftRepository;
        }
        public async Task<GetGiftResponse> CreateGift(CreateGiftDto dto, CancellationToken ct)
        {
            var gift = dto.ToEntity<T>();
            _dbContext.Set<T>().Add(gift);
            await _dbContext.SaveChangesAsync(ct);

            var response = await _giftRepository.GetById(gift.Id);
            return response is not null
                ? response.ToResponse()
                : throw new Exception("Gift creation failed.");
        }

        public async Task<bool?> DeleteGift(int id)
        {
            await _giftRepository.Delete(id);
            return true;
        }

        public async Task<bool?> UpdateGift(int id, CreateGiftDto dto, CancellationToken ct)
        {
            var gift = await _giftRepository.GetById(id);
            if (gift == null) throw new KeyNotFoundException($"Gift {id} not found.");

            gift.Name = dto.Name;
            gift.ImageUrl = dto.ImageUrl;
            gift.Price = dto.Price;

            await _dbContext.SaveChangesAsync(ct);
            return true;
        }
    }
}
