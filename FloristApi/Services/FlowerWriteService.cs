using FloristApi.Data;
using FloristApi.Integrations.Payment;
using FloristApi.Models.Dtos.admin;
using FloristApi.Models.Dtos.@public;
using FloristApi.Models.Entities;
using FloristApi.Models.Mappings;
using FloristApi.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Stripe;

namespace FloristApi.Services
{
    public class FlowerWriteService : IFlowerWriteService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IFlowerRepository _flowerRepository;
        private readonly IBlobService _blobService;
        private readonly IStripeService _stripeService;
        public FlowerWriteService(ApplicationDbContext dbContext, IFlowerRepository flowerRepository, IBlobService blobService, IStripeService stripeService)
        {
            _dbContext = dbContext;
            _flowerRepository = flowerRepository;
            _blobService = blobService;
            _stripeService = stripeService;
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

            // create flower in stripe if error remove flower in db
            try
            {
                var (productId, priceId) = await _stripeService.CreateStripeProduct(flower, ct);
                flower.StripeProductId = productId;
                flower.StripePriceId = priceId;
                await _dbContext.SaveChangesAsync();
            }
            catch
            {
                _dbContext.Flowers.Remove(flower);
                await _dbContext.SaveChangesAsync();
                throw;
            }
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

            flower.ProductType  = dto.ProductType;
            flower.Color        = dto.Color;
            flower.Occasion     = dto.Occasion;
            
            flower.Price        = dto.Price;
            flower.Discount     = dto.Discount ?? 0;
            flower.IsPopular    = dto.isPopular ?? false;
            flower.FlowerTypes.Clear();
            foreach (var t in types)
                flower.FlowerTypes.Add(t);
            if(flower.ImageUrl != dto.ImageUrl)
            {
                await _blobService.DeleteAsync(flower.ImageUrl, ct);
            }
            flower.ImageUrl = dto.ImageUrl;

            await _dbContext.SaveChangesAsync(ct);
            return true;
        }
        public async Task DeleteFlower(int id, CancellationToken ct = default)
        {
            var flower = await _flowerRepository.GetById(id, ct);
            if (flower == null) throw new KeyNotFoundException($"Flower {id} not found.");
            await _blobService.DeleteAsync(flower.ImageUrl, ct);
            var removed = await _flowerRepository.Delete(id, ct);
            if (!removed) throw new KeyNotFoundException($"Flower {id} not found.");
        }

        public async Task<IEnumerable<GetFlowerAdminResponse>> GetFlowersAdmin(CancellationToken ct = default)
        {
            var flowers = await _flowerRepository.GetAll(ct);
            return flowers.Select(flower => new GetFlowerAdminResponse
            {
                Id = flower.Id,
                Name = flower.Name,
                Description = flower.Description,
                ImageUrl = flower.ImageUrl,

                ProductType = flower.ProductType,
                Color = flower.Color,
                Occasion = flower.Occasion,

                Price = flower.Price,
                Discount = flower.Discount,
                IsPopular = flower.IsPopular,

                CreatedAt = flower.CreatedAt,
                FlowerTypes = flower.FlowerTypes
                    .OrderBy(ft => ft.Name)
                    .Select(ft => ft.Name)
                    .ToList(),
                StripeProductId = flower.StripeProductId,
                StripePriceId = flower.StripePriceId
            });
        }
    }
}
