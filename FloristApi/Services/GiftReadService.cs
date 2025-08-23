using FloristApi.Models.Dtos.@public;
using FloristApi.Models.Entities;
using FloristApi.Repositories;
using FloristApi.Models.Mappings;

namespace FloristApi.Services
{
    public class GiftReadService<T> : IGiftReadService<T> where T : class, IGiftEntity
    {
        private readonly IGiftRepository<T> _giftRepository;
        public GiftReadService(IGiftRepository<T> giftRepository)
        {
            _giftRepository = giftRepository;
        }

        public async Task<IEnumerable<GetGiftResponse>> GetAllGifts(CancellationToken ct = default)
        {
            var gifts = await _giftRepository.GetAll(ct);
            return gifts.Select(gifts => gifts.ToResponse());
        }

        public async Task<GetGiftResponse> GetGiftById(int id, CancellationToken ct = default)
        {
            var gift = await _giftRepository.GetById(id, ct);
            if (gift is null)
            {
                throw new KeyNotFoundException($"Flower with ID {id} not found.");
            }
            return gift.ToResponse();
        }
    }
}
