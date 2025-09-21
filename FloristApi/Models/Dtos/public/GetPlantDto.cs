using FloristApi.Enums;

namespace FloristApi.Models.Dtos.@public
{
    public class GetPlantDto
{
        public int? Page { get; set; }
        public int? PageSize { get; set; }
        public PlantTypes? PlantType { get; set; }
        public int? MinPrice { get; set; }
        public int? MaxPrice { get; set; }
        public string? SearchTerm { get; set; }
        public SortBy? Sort { get; set; } = SortBy.IdAsc;
    }
}
