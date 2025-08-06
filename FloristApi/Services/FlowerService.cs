using FloristApi.Models.Dtos;
using FloristApi.Models.Mappings;
using FloristApi.Repositories;

namespace FloristApi.Services
{
    public class FlowerService: IFlowerService
    {
        private readonly IFlowerRepository _flowerRepository;
        public FlowerService(IFlowerRepository flowerRepository)
        {
            _flowerRepository = flowerRepository;
        }
        public async Task<GetFlowerResponse> CreateFlower(CreateFlowerDto dto)
        {
            var flower = dto.ToEntity();
            await _flowerRepository.Add(flower);
            var response = await _flowerRepository.GetById(flower.Id);
            return response is not null
                ? response.ToResponse()
                : throw new Exception("Flower creation failed.");
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
