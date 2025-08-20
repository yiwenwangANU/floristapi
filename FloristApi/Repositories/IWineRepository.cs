using FloristApi.Models.Entities;

namespace FloristApi.Repositories
{
    public interface IWineRepository
    {
        Task<IEnumerable<Wine>> GetAll();
        Task Add(Wine entity);
    }
}
