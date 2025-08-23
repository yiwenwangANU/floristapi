using FloristApi.Data;
using Microsoft.EntityFrameworkCore;

namespace FloristApi.Repositories
{
    public class GiftRepository<T>: IGiftRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        public GiftRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task Add(T entity, CancellationToken ct = default)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync(ct);
        }

        public async Task Update(T entity, CancellationToken ct = default)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync(ct);
        }
        public async Task<bool> Delete(int id, CancellationToken ct = default)
        {
            var gift = await _context.Set<T>().FindAsync(id, ct);
            if (gift == null) return false;

            _context.Set<T>().Remove(gift);
            await _context.SaveChangesAsync(ct);
            return true;
        }
        public async Task<IEnumerable<T>> GetAll(CancellationToken ct = default)
        {
            return await _context.Set<T>().AsNoTracking().ToListAsync(ct);
        }

        public async Task<T?> GetById(int id, CancellationToken ct = default)
        {
            return await _context.Set<T>().FindAsync(id, ct);
        }
    }
}
