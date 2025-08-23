using FloristApi.Data;
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
        public async Task<IEnumerable<Flower>> GetAll(CancellationToken ct = default)
        {
            return await _context.Flowers.ToListAsync(ct);
        }

        public async Task<Flower?> GetById(int id, CancellationToken ct = default)
        {
            return await _context.Flowers
                .Include(f => f.FlowerTypes)
                .FirstOrDefaultAsync(f => f.Id == id, ct);
        }
    }
}
