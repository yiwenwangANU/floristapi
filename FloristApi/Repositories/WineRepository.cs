using FloristApi.Data;
using FloristApi.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace FloristApi.Repositories
{
    public class WineRepository : IWineRepository
    {
        private readonly ApplicationDbContext _context;
        public WineRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task Add(Wine entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Wine>> GetAll()
        {
            return await _context.Wines.ToListAsync();
        }
    }
}
