using FloristApi.Models.Dtos;

namespace FloristApi.Services
{
    public interface IFlowerService
    {
        Task<GetFlowerResponse> CreateFlower(CreateFlowerDto dto);
        Task<IEnumerable<GetFlowerResponse>> GetFlowers();
        Task<GetFlowerResponse> GetFlowerById(int id);
    }
}
