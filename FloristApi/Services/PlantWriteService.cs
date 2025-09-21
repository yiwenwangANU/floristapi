using FloristApi.Data;
using FloristApi.Models.Dtos.admin;
using FloristApi.Models.Dtos.@public;
using FloristApi.Models.Mappings;
using FloristApi.Repositories;

namespace FloristApi.Services
{
    public class PlantWriteService: IPlantWriteService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IPlantRepository _plantRepository;
        private readonly IBlobService _blobService;
        public PlantWriteService(ApplicationDbContext dbContext, IPlantRepository plantRepository, IBlobService blobService)
        {
            _dbContext = dbContext;
            _plantRepository = plantRepository;
            _blobService = blobService;
        }
        public async Task<GetPlantResponse> CreatePlant(CreatePlantDto dto, CancellationToken ct = default)
        {
            var plant = dto.ToEntity();
            _dbContext.Plants.Add(plant);
            await _dbContext.SaveChangesAsync(ct);

            var response = await _plantRepository.GetById(plant.Id, ct);
            return response is not null
                ? response.ToResponse()
                : throw new Exception("Plant creation failed.");
        }
        public async Task<bool?> UpdatePlant(int id, CreatePlantDto dto, CancellationToken ct = default)
        {
            var plant = await _plantRepository.GetById(id, ct);
            if (plant == null) throw new KeyNotFoundException($"Plant {id} not found.");

            plant.Name = dto.Name;
            plant.Description = dto.Description;

            plant.PlantType = dto.PlantType;

            plant.Price = dto.Price;
            plant.Discount = dto.Discount ?? 0;

            plant.ImageUrl = dto.ImageUrl;

            await _dbContext.SaveChangesAsync(ct);
            return true;
        }
        public async Task DeletePlant(int id, CancellationToken ct = default)
        {
            var plant = await _plantRepository.GetById(id, ct);
            if (plant == null) throw new KeyNotFoundException($"Plant {id} not found.");
            await _blobService.DeleteAsync(plant.ImageUrl, ct);
            var removed = await _plantRepository.Delete(id, ct);
            if (!removed) throw new KeyNotFoundException($"Plant {id} not found.");
        }

        
    }
}
