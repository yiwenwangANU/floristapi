using FloristApi.Enums;

namespace FloristApi.Models.Dtos.@public
{
    public class GetPlantResponse
{
        ublic int Id { get; set; } = 0;
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public int Price { get; set; }
        public ProductTypes ProductType { get; set; }
        public int? Discount { get; set; } = 0;
    }
}
