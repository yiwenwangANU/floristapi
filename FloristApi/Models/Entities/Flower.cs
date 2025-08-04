using FloristApi.Enums;
using System.ComponentModel.DataAnnotations;

namespace FloristApi.Models.Entities
{
    public class Flower
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public int Price { get; set; };
        public int Discount { get; set; } = 0;
        public ProductTypes ProductType { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
