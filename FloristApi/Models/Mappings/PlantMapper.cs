using FloristApi.Models.Dtos.admin;
using FloristApi.Models.Dtos.@public;
using FloristApi.Models.Entities;

namespace FloristApi.Models.Mappings
{
    public static class PlantMapper
    {
        public static Plant ToEntity(this CreatePlantDto dto)
        {
            return new Plant
            {
                Name = dto.Name,
                Description = dto.Description,
                ImageUrl = dto.ImageUrl,

                PlantType = dto.PlantType,

                Price = dto.Price,
                Discount = dto.Discount ?? 0,
            };
        }

        public static GetPlantResponse ToResponse(this Plant plant)
        {
            return new GetPlantResponse
            {
                Id = plant.Id,
                Name = plant.Name,
                Description = plant.Description,
                ImageUrl = plant.ImageUrl,
                Price = plant.Price,
                PlantType = plant.PlantType,
                Discount = plant.Discount
            };
        }
    }
}
