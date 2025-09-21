using FloristApi.Data;
using FloristApi.Models.Dtos.@public;
using FloristApi.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace FloristApi.Repositories
{
    public class PlantRepository : IPlantRepository
    {
        private readonly ApplicationDbContext _context;
        public PlantRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task Add(Plant entity, CancellationToken ct = default)
        {
            await _context.Plants.AddAsync(entity, ct);
            await _context.SaveChangesAsync(ct);
        }

        public async Task Update(Plant entity, CancellationToken ct = default)
        {
            _context.Plants.Update(entity);
            await _context.SaveChangesAsync(ct);
        }
        public async Task<bool> Delete(int id, CancellationToken ct = default)
        {
            var plant = await _context.Plants.FirstOrDefaultAsync(x => x.Id == id, ct);
            if (plant == null) return false;

            _context.Plants.Remove(plant);
            await _context.SaveChangesAsync(ct);
            return true;
        }
        public async Task<IEnumerable<Plant>> GetPlant(GetPlantQuery query, CancellationToken ct = default)
        {
            IQueryable<Plant> q = _context.Plants.AsNoTracking();
            // Apply filters
            if (query.PlantType.HasValue)
                q = q.Where(f => f.PlantType == query.PlantType.Value);

            if (query.MinPrice.HasValue)
                q = q.Where(f => f.Price >= query.MinPrice.Value);

            if (query.MaxPrice.HasValue)
                q = q.Where(f => f.Price <= query.MaxPrice.Value);

            if (!string.IsNullOrWhiteSpace(query.SearchTerm))
                q = q.Where(f => f.Name.Contains(query.SearchTerm));
            // Apply sorting
            q = query.Sort switch
            {
                SortBy.IdAsc => q.OrderBy(f => f.Id),
                SortBy.IdDesc => q.OrderByDescending(f => f.Id),
                SortBy.PriceAsc => q.OrderBy(f => f.Price),
                SortBy.PriceDesc => q.OrderByDescending(f => f.Price),
                _ => q.OrderBy(f => f.Id)
            };
            // Apply pagination
            q = q.Skip((query.Page - 1) * query.PageSize).Take(query.PageSize);
            return await q.ToListAsync(ct);
        }
        public async Task<IEnumerable<Plant>> GetAll(CancellationToken ct = default)
        {
            return await _context.Plants
                .Include(f => f.PlantType)
                .AsNoTracking()
                .ToListAsync(ct);
        }

        public async Task<Plant?> GetById(int id, CancellationToken ct = default)
        {
            return await _context.Plants
                .Include(f => f.PlantType)
                .AsNoTracking()
                .FirstOrDefaultAsync(f => f.Id == id, ct);
        }
    
    }
}
