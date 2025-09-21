using FloristApi.Enums;

namespace FloristApi.Models.Entities
{
    public class Plant
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;

        public PlantTypes PlantType { get; set; }

        public int Price { get; set; }
        public int Discount { get; set; } = 0;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
