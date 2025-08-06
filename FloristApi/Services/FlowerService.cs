using FloristApi.Models.Dtos;
using FloristApi.Models.Entities;
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
            var flower = new Flower
            {
                Name = dto.Name,
                Description = dto.Description,
                ImageUrl = dto.ImageUrl,
                Price = dto.Price,
                ProductType = dto.ProductType,
                Discount = dto.Discount ?? 0
            };
            await _flowerRepository.Add(flower);
            var response = await _flowerRepository.GetById(flower.Id);
            return response is not null
                ? new GetFlowerResponse
                {
                    Name = response.Name,
                    Description = response.Description,
                    ImageUrl = response.ImageUrl,
                    Price = response.Price,
                    ProductType = response.ProductType,
                    Discount = response.Discount
                }
                : throw new Exception("Flower creation failed.");
        }

        Task<IEnumerable<GetFlowerResponse>> IFlowerService.GetFlowers()
        {
            return await _flowerRepository.GetAll()
                .ContinueWith(task => task.Result.Select(flower => new GetFlowerResponse
                {
                    Name = flower.Name,
                    Description = flower.Description,
                    ImageUrl = flower.ImageUrl,
                    Price = flower.Price,
                    ProductType = flower.ProductType,
                    Discount = flower.Discount
                }));
        }

        Task<GetFlowerResponse> IFlowerService.GetFlowerById(int id)
        {
            throw new NotImplementedException();
        }
    }
    {
    }
}
