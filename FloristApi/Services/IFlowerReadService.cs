using FloristApi.Models.Dtos.admin;
using FloristApi.Models.Dtos.@public;

namespace FloristApi.Services
{
    public interface IFlowerReadService
    {
        
        Task<IEnumerable<GetFlowerResponse>> GetFlowers();
        Task<GetFlowerResponse> GetFlowerById(int id);
    }
}
