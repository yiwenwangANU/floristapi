using FloristApi.Models.Dtos.@public;
using FloristApi.Models.Mappings;
using FloristApi.Repositories;

namespace FloristApi.Services
{
    public class PlantReadService: IPlantReadService
    {
        private readonly IPlantRepository _plantRepository;
        public PlantReadService(IPlantRepository plantRepository)
        {
            _plantRepository = plantRepository;
        }

        public async Task<IEnumerable<GetPlantResponse>> GetPlants(GetPlantDto dto, CancellationToken ct = default)
        {
            var queryPage = (dto.Page is > 0) ? dto.Page.Value : 1;
            var queryPageSize = (dto.PageSize is > 0) ? dto.PageSize.Value : 12;
            var querySort = dto.Sort ?? SortBy.IdAsc;
            var query = new GetPlantQuery
            {
                Page = queryPage,
                PageSize = queryPageSize,
                PlantType = dto.PlantType,
                MinPrice = dto.MinPrice,
                MaxPrice = dto.MaxPrice,
                SearchTerm = dto.SearchTerm,
                Sort = querySort,
            };
            var plants = await _plantRepository.GetPlant(query, ct);
            return plants.Select(plant => plant.ToResponse());
        }

        public async Task<GetPlantResponse> GetPlantById(int id, CancellationToken ct = default)
        {
            var plant = await _plantRepository.GetById(id, ct);
            if (plant is null)
            {
                throw new KeyNotFoundException($"Plant with ID {id} not found.");
            }
            return plant.ToResponse();
        }
    }
}
}
