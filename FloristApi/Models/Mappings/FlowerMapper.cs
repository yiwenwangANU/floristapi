using FloristApi.Models.Dtos;
using FloristApi.Models.Entities;

namespace FloristApi.Models.Mappings
{
    public static class FlowerMapper 
    {
        public static Flower ToEntity(this CreateFlowerDto dto)
        {
            return new Flower
            {
                Name = dto.Name,
                Description = dto.Description,
                ImageUrl = dto.ImageUrl,

                ProductType = dto.ProductType,
                Color = dto.Color,
                Occasion = dto.Occasion,

                Price = dto.Price,
                Discount = dto.Discount ?? 0,
                IsPopular = dto.isPopular ?? false,
            };
        }

        public static GetFlowerResponse ToResponse(this Flower flower)
        {
            return new GetFlowerResponse
            {
                Name = flower.Name,
                Description = flower.Description,
                ImageUrl = flower.ImageUrl,
                Price = flower.Price,
                ProductType = flower.ProductType,
                Discount = flower.Discount
            };
        }
    }
}
