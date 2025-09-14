using FloristApi.Enums;

namespace FloristApi.Models.Dtos.@public
{
    public class GetFlowerQuery
    {
        public required int Page { get; set; }
        public required int PageSize { get; set; }
        public ProductTypes? ProductType { get; set; }
        public ColorTypes? Color { get; set; }
        public OccasionTypes? Occasion { get; set; }
        public List<FlowerTypes>? FlowerType { get; set; }
        public int? MinPrice { get; set; }
        public int? MaxPrice { get; set; }
        public string? SearchTerm { get; set; }
        public SortBy Sort { get; set; }
    }

    public enum SortBy
    {
        IdAsc, IdDesc, PriceAsc, PriceDesc
    }
}
