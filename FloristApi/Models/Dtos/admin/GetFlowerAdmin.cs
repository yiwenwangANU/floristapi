using FloristApi.Enums;

namespace FloristApi.Models.Dtos.admin
{
    public class GetFlowerAdmin
    {
        public int Id { get; set; } = 0;
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        
        public ProductTypes ProductType { get; set; }
        public ColorTypes Color {  get; set; }
        public OccasionTypes Occasion { get; set; }

        public int Price { get; set; }
        public int? Discount { get; set; } = 0;
        public bool IsPopular { get; set; }

        public HashSet<int> FlowerTypes { get; set; } = new HashSet<int>();
    }
}
