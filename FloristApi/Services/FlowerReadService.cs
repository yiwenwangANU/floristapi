using FloristApi.Models.Dtos.@public;
using FloristApi.Models.Mappings;
using FloristApi.Repositories;


namespace FloristApi.Services
{
    public class FlowerReadService: IFlowerReadService
    {
        private readonly IFlowerRepository _flowerRepository;
        public FlowerReadService(IFlowerRepository flowerRepository)
        {
            _flowerRepository = flowerRepository;
        }
        
        public async Task<IEnumerable<GetFlowerResponse>> GetFlowers(GetFlowerDto dto, CancellationToken ct = default)
        {
            var queryPage = (dto.Page is > 0) ? dto.Page.Value : 1;
            var queryPageSize = (dto.PageSize is > 0) ? dto.PageSize.Value : 12;
            var querySort = dto.Sort ?? SortBy.IdAsc; 
            var query = new GetFlowerQuery
            {
                Page = queryPage,
                PageSize = queryPageSize,
                ProductType = dto.ProductType,
                Color = dto.Color,
                Occasion = dto.Occasion,
                FlowerTypeIds = dto.FlowerTypeIds,
                MinPrice = dto.MinPrice,
                MaxPrice = dto.MaxPrice,
                SearchTerm = dto.SearchTerm,
                Sort = querySort,
            };
            var flowers = await _flowerRepository.GetFlower(query, ct);
            return flowers.Select(flower => flower.ToResponse());
        }

        public async Task<GetFlowerResponse> GetFlowerById(int id, CancellationToken ct = default)
        {
            var flower = await _flowerRepository.GetById(id, ct);
            if (flower is null)
            {
                throw new KeyNotFoundException($"Flower with ID {id} not found.");
            }
            return flower.ToResponse();
        }
    }
}
