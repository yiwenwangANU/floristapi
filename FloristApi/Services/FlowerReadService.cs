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
        
        public async Task<IEnumerable<GetFlowerResponse>> GetFlowers()
        {
            var flowers = await _flowerRepository.GetAll();
            return flowers.Select(flower => flower.ToResponse());
        }

        public async Task<GetFlowerResponse> GetFlowerById(int id)
        {
            var flower = await _flowerRepository.GetById(id);
            if (flower is null)
            {
                throw new KeyNotFoundException($"Flower with ID {id} not found.");
            }
            return flower.ToResponse();
        }
    }
}
