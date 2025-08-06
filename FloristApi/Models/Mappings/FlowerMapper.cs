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
                Price = dto.Price,
                ProductType = dto.ProductType,
                Discount = dto.Discount ?? 0
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
