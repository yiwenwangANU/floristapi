using FloristApi.Data;
using FloristApi.Models.Dtos.admin;
using FloristApi.Models.Dtos.@public;
using FloristApi.Models.Entities;
using FloristApi.Models.Mappings;
using FloristApi.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace FloristApi.Services
{
    public class FlowerWriteService : IFlowerWriteService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IFlowerRepository _flowerRepository;
        private readonly IBlobService _blobService;
        public FlowerWriteService(ApplicationDbContext dbContext, IFlowerRepository flowerRepository, IBlobService blobService)
        {
            _dbContext = dbContext;
            _flowerRepository = flowerRepository;
            _blobService = blobService;
        }
        public async Task<GetFlowerResponse> CreateFlower(CreateFlowerDto dto, CancellationToken ct = default)
        {
            var flower = dto.ToEntity();
            var types = await _dbContext.FlowerTypes
                .Where(ft => dto.FlowerTypeIds.Contains(ft.Id))
                .ToListAsync(ct);
            if (types.Count != dto.FlowerTypeIds.Count)
            {
                var foundIds = types.Select(t => t.Id).ToHashSet();
                var missingIds = dto.FlowerTypeIds.Where(id => !foundIds.Contains(id));
                throw new ArgumentException($"Unknown FlowerTypeIds: {string.Join(", ", missingIds)}");
            }

            foreach (var t in types)
                flower.FlowerTypes.Add(t);
            _dbContext.Flowers.Add(flower);
            await _dbContext.SaveChangesAsync(ct);

            var response = await _flowerRepository.GetById(flower.Id, ct);
            return response is not null
                ? response.ToResponse()
                : throw new Exception("Flower creation failed.");
        }
        public async Task<bool?> UpdateFlower(int id, CreateFlowerDto dto, CancellationToken ct = default)
        {
            var flower = await _flowerRepository.GetById(id, ct);
            if (flower == null) throw new KeyNotFoundException($"Flower {id} not found.");

            var types = await _dbContext.FlowerTypes
                .Where(ft => dto.FlowerTypeIds.Contains(ft.Id))
                .ToListAsync(ct);
            if (types.Count != dto.FlowerTypeIds.Count)
            {
                var foundIds = types.Select(t => t.Id).ToHashSet();
                var missingIds = dto.FlowerTypeIds.Where(id => !foundIds.Contains(id));
                throw new ArgumentException($"Unknown FlowerTypeIds: {string.Join(", ", missingIds)}");
            }

            flower.Name         = dto.Name;
            flower.Description  = dto.Description;
            flower.ImageUrl     = dto.ImageUrl;

            flower.ProductType  = dto.ProductType;
            flower.Color        = dto.Color;
            flower.Occasion     = dto.Occasion;
            
            flower.Price        = dto.Price;
            flower.Discount     = dto.Discount ?? 0;
            flower.IsPopular    = dto.isPopular ?? false;
            flower.FlowerTypes.Clear();
            foreach (var t in types)
                flower.FlowerTypes.Add(t);
            await _dbContext.SaveChangesAsync(ct);
            return true;
        }
        public async Task DeleteFlower(int id, CancellationToken ct = default)
        {
            var flower = await _flowerRepository.GetById(id, ct);
            if (flower == null) throw new KeyNotFoundException($"Flower {id} not found.");
            var blobName = flower.ImageUrl;
            await _blobService.DeleteAsync(blobName, ct);
            var removed = await _flowerRepository.Delete(id, ct);
            if (!removed) throw new KeyNotFoundException($"Flower {id} not found.");
        }

        public async Task<IEnumerable<Flower>> GetFlowersAdmin(CancellationToken ct = default)
        {
            var flowers = await _flowerRepository.GetAll(ct);
            return flowers;
        }
    }
}
