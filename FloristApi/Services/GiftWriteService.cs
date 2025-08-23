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
        private readonly IBlobService _blobService;
        public GiftWriteService(ApplicationDbContext dbContext, IGiftRepository<T> giftRepository, IBlobService blobService)
        {
            _dbContext = dbContext;
            _giftRepository = giftRepository;
            _blobService = blobService;
        }
        public async Task<GetGiftResponse> CreateGift(CreateGiftDto dto, CancellationToken ct = default)
        {
            var gift = dto.ToEntity<T>();
            _dbContext.Set<T>().Add(gift);
            await _dbContext.SaveChangesAsync(ct);

            var response = await _giftRepository.GetById(gift.Id);
            return response is not null
                ? response.ToResponse()
                : throw new Exception("Gift creation failed.");
        }

        public async Task DeleteGift(int id, CancellationToken ct = default)
        {
            var gift = await _giftRepository.GetById(id, ct);
            if (gift == null) throw new KeyNotFoundException($"Gift {id} not found.");
            var blobName = gift.ImageUrl;
            await _blobService.DeleteAsync(blobName, ct);
            var removed = await _giftRepository.Delete(id, ct);
            if (!removed) throw new KeyNotFoundException($"Gift {id} not found.");
        }

        public async Task<bool?> UpdateGift(int id, CreateGiftDto dto, CancellationToken ct = default)
        {
            var gift = await _giftRepository.GetById(id, ct);
            if (gift == null) throw new KeyNotFoundException($"Gift {id} not found.");

            gift.Name = dto.Name;
            gift.Price = dto.Price;
            if(gift.ImageUrl != dto.ImageUrl)
            {
               await _blobService.DeleteAsync(gift.ImageUrl, ct);
            }
            gift.ImageUrl = dto.ImageUrl;
            
            await _dbContext.SaveChangesAsync(ct);
            return true;
        }
    }
}
