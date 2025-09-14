using FloristApi.Enums;

namespace FloristApi.Models.Dtos.@public
{
    public class GetFlowerDto
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 12;
        public ProductTypes? ProductType { get; set; }
        public ColorTypes? Color { get; set; }
        public OccasionTypes? Occasion { get; set; }
        public FlowerTypes? FlowerType { get; set; }
        public int? MinPrice { get; set; }
        public int? MaxPrice { get; set; }
        public string? SearchTerm { get; set; } = string.Empty;
        public SortBy Sort { get; set; } = SortBy.IdAsc;
    }

    public enum SortBy
    {
        IdAsc, IdDesc, PriceAsc, PriceDesc
    }
}
