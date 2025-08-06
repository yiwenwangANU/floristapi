using FloristApi.Models.Dtos;
using FloristApi.Models.Entities;
using FloristApi.Models.Mappings;
using FloristApi.Repositories;
using Microsoft.JSInterop.Infrastructure;

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

        public async Task<IEnumerable<GetFlowerResponse>> IFlowerService.GetFlowers()
        {
            var flowers = await _flowerRepository.GetAll();
            return flowers.Select(flower => flower.ToResponse());
        }

        Task<GetFlowerResponse> IFlowerService.GetFlowerById(int id)
        {
            throw new NotImplementedException();
        }
    }
    {
    }
}
