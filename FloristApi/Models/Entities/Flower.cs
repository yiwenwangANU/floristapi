using Azure;
using FloristApi.Enums;
using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations;

namespace FloristApi.Models.Entities
{
    public class Flower
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;

        public ProductTypes ProductType { get; set; }
        public ColorTypes Color { get; set; }
        public OccasionTypes Occasion { get; set; }

        public int Price { get; set; }
        public int Discount { get; set; } = 0;
        public bool IsPopular { get; set; } = false;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public HashSet<FlowerType> FlowerTypes { get; } = [];
    }

    public class FlowerType
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public HashSet<Flower> Flowers { get; } = [];
    }
}
