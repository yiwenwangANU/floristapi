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

        public async Task Update(Flower entity)
        {
            _context.Flowers.Update(entity);
            await _context.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            var flower =  await _context.Flowers.FirstOrDefaultAsync(x => x.Id == id);
            if (flower == null) return;

            _context.Flowers.Remove(flower);
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
