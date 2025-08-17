using FloristApi.Data;
using FloristApi.Models.Dtos;
using FloristApi.Models.Mappings;
using FloristApi.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FloristApi.Services
{
    public class FlowerService: IFlowerService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IFlowerRepository _flowerRepository;
        public FlowerService(ApplicationDbContext dbContext, IFlowerRepository flowerRepository)
        {
            _dbContext = dbContext;
            _flowerRepository = flowerRepository;
        }
        public async Task<GetFlowerResponse> CreateFlower(CreateFlowerDto dto)
        {
            var flower = dto.ToEntity();
            var types = await _dbContext.FlowerTypes
                .Where(ft => dto.FlowerTypeIds.Contains(ft.Id))
                .ToListAsync();
            if (types.Count != dto.FlowerTypeIds.Count)
            {
                var foundIds = types.Select(t => t.Id).ToHashSet();
                var missingIds = dto.FlowerTypeIds.Where(id => !foundIds.Contains(id));
                throw new ArgumentException($"Unknown FlowerTypeIds: {string.Join(", ", missingIds)}");
            }
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
