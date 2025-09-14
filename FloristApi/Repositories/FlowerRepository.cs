using FloristApi.Data;
using FloristApi.Models.Dtos.@public;
using FloristApi.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace FloristApi.Repositories
{
    public class FlowerRepository : IFlowerRepository
    {
        private readonly ApplicationDbContext _context;
        public FlowerRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task Add(Flower entity, CancellationToken ct = default)
        {
            await _context.Flowers.AddAsync(entity, ct);
            await _context.SaveChangesAsync(ct);
        }

        public async Task Update(Flower entity, CancellationToken ct = default)
        {
            _context.Flowers.Update(entity);
            await _context.SaveChangesAsync(ct);
        }
        public async Task<bool> Delete(int id, CancellationToken ct = default)
        {
            var flower =  await _context.Flowers.FirstOrDefaultAsync(x => x.Id == id, ct);
            if (flower == null) return false;

            _context.Flowers.Remove(flower);
            await _context.SaveChangesAsync(ct);
            return true;
        }
        public async Task<IEnumerable<Flower>> GetFlower(GetFlowerQuery query, CancellationToken ct = default)
        {
            IQueryable<Flower> q = _context.Flowers.AsNoTracking();
            // Apply filters
            if (query.ProductType.HasValue)
                q = q.Where(f => f.ProductType == query.ProductType.Value);

            if (query.Color.HasValue)
                q = q.Where(f => f.Color == query.Color.Value);

            if (query.Occasion.HasValue)
                q = q.Where(f => f.Occasion == query.Occasion.Value);

            if (query.FlowerType is { Count: > 0 })
                q = q.Where(f=> f.FlowerTypes.Any(ft => ft.Name == query.FlowerType.ToString()));

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
        public async Task<IEnumerable<Flower>> GetAll(CancellationToken ct = default)
        {
            return await _context.Flowers
                .Include(f => f.FlowerTypes)
                .AsNoTracking()
                .ToListAsync(ct);
        }

        public async Task<Flower?> GetById(int id, CancellationToken ct = default)
        {
            return await _context.Flowers
                .Include(f => f.FlowerTypes)
                .AsNoTracking()
                .FirstOrDefaultAsync(f => f.Id == id, ct);
        }
    }
}
