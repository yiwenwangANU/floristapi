using FloristApi.Models.Dtos;

namespace FloristApi.Services
{
    public class FlowerService: IFlowerService
    {
        
        public Task<GetFlowerResponse> CreateFlower(CreateFlowerDto dto)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<GetFlowerResponse>> IFlowerService.GetFlowers()
        {
            throw new NotImplementedException();
        }

        Task<GetFlowerResponse> IFlowerService.GetFlowerById(int id)
        {
            throw new NotImplementedException();
        }
    }
    {
    }
}
