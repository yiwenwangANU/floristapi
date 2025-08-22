using FloristApi.Data;
using FloristApi.Models.Dtos.admin;
using FloristApi.Models.Dtos.@public;
using FloristApi.Models.Mappings;
using FloristApi.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FloristApi.Services
{
    public class FlowerReadService: IFlowerReadService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IFlowerRepository _flowerRepository;
        public FlowerReadService(ApplicationDbContext dbContext, IFlowerRepository flowerRepository)
        {
            _dbContext = dbContext;
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
