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
        public async Task Add(Flower entity)
        {
            await _context.Flowers.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Flower>> GetAll()
        {
            return await _context.Flowers.ToListAsync();
        }

        public async Task<Flower?> GetById(int id)
        {
            return await _context.FindAsync<Flower>(id);
        }
    }
}
