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
        public async Task Add(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
        }
        public async Task<bool> Delete(int id)
        {
            var gift = await _context.Set<T>().FindAsync(id);
            if (gift == null) return false;

            _context.Set<T>().Remove(gift);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<IEnumerable<T>> GetAll()
        {
            return await _context.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<T?> GetById(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }
    }
}
