using FloristApi.Models.Entities;

namespace FloristApi.Repositories
{
    public interface IFlowerRepository
    {
        Task<IEnumerable<Flower>> GetAll();
        Task<Flower?> GetById(int id);
        Task Add(Flower entity);
    }
}
