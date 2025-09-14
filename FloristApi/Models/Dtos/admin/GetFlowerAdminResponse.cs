using FloristApi.Enums;
using FloristApi.Models.Entities;

namespace FloristApi.Models.Dtos.admin
{
    public class GetFlowerAdminResponse
    {
        public int Id { get; init; }
        public required string Name { get; init; } 
        public required string Description { get; init; } 
        public required string ImageUrl { get; init; } 

        public ProductTypes ProductType { get; init; }
        public ColorTypes Color { get; init; }
        public OccasionTypes Occasion { get; init; }

        public int Price { get; init; }
        public int Discount { get; init; }
        public bool IsPopular { get; init; }

        public DateTime CreatedAt { get; init; } = DateTime.UtcNow;
        public List<string> FlowerTypes { get; init; } = [];
    }
}
