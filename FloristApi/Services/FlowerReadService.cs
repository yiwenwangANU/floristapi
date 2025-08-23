using FloristApi.Models.Dtos.@public;
using FloristApi.Models.Mappings;
using FloristApi.Repositories;


namespace FloristApi.Services
{
    public class FlowerReadService: IFlowerReadService
    {
        private readonly IFlowerRepository _flowerRepository;
        public FlowerReadService(IFlowerRepository flowerRepository)
        {
            _flowerRepository = flowerRepository;
        }
        
        public async Task<IEnumerable<GetFlowerResponse>> GetFlowers(CancellationToken ct = default)
        {
            var flowers = await _flowerRepository.GetAll(ct);
            return flowers.Select(flower => flower.ToResponse());
        }

        public async Task<GetFlowerResponse> GetFlowerById(int id, CancellationToken ct = default)
        {
            var flower = await _flowerRepository.GetById(id, ct);
            if (flower is null)
            {
                throw new KeyNotFoundException($"Flower with ID {id} not found.");
            }
            return flower.ToResponse();
        }
    }
}
