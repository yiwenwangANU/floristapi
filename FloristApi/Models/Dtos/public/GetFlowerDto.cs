using FloristApi.Enums;

namespace FloristApi.Models.Dtos.@public
{
    public class GetFlowerDto
{
        public int? Page { get; set; }
        public int? PageSize { get; set; }
        public ProductTypes? ProductType { get; set; }
        public ColorTypes? Color { get; set; }
        public OccasionTypes? Occasion { get; set; }
        public List<int>? FlowerTypeIds { get; set; }
        public int? MinPrice { get; set; }
        public int? MaxPrice { get; set; }
        public string? SearchTerm { get; set; }
        public SortBy? Sort { get; set; } = SortBy.IdAsc;
    }
}
