using FloristApi.Models.Dtos.admin;
using FloristApi.Models.Dtos.@public;
using FloristApi.Models.Entities;

namespace FloristApi.Models.Mappings
{
    public static class GiftMapper
    {
        public static T ToEntity<T>(this CreateGiftDto dto) 
            where T : class, IGiftEntity, new()
        {
            return new T
            {
                Name = dto.Name,
                ImageUrl = dto.ImageUrl,
                Price = dto.Price
            };
        }

        public static GetGiftResponse ToResponse<T>(this T entity)
            where T : class, IGiftEntity
        {
            return new GetGiftResponse
            {
                Id = entity.Id,
                Name = entity.Name,
                ImageUrl = entity.ImageUrl,
                Price = entity.Price,
            };
        }
    }
}
