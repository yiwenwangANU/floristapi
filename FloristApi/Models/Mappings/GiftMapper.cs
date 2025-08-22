using FloristApi.Models.Dtos;
using FloristApi.Models.Dtos.admin;
using FloristApi.Models.Entities;
using System.Runtime.CompilerServices;

namespace FloristApi.Models.Mappings
{
    public static class GiftMapper
    {
        public static Wine ToEntityWine(this CreateGiftDto dto)
        {
            return new Wine
            {
                Name = dto.Name,
                ImageUrl = dto.ImageUrl,
                Price = dto.Price,
            };
        }
        public static Teddy ToEntityTeddy(this CreateGiftDto dto)
        {
            return new Teddy
            {
                Name = dto.Name,
                ImageUrl = dto.ImageUrl,
                Price = dto.Price,
            };
        }

        public static Chocolate ToEntityChocolate(this CreateGiftDto dto)
        {
            return new Chocolate
            {
                Name = dto.Name,
                ImageUrl = dto.ImageUrl,
                Price = dto.Price,
            };
        }

        public static GetGiftResponse ToResponseWine(this Wine wine)
        {
            return new GetGiftResponse
            {
                Id = wine.Id,
                Name = wine.Name,
                ImageUrl = wine.ImageUrl,
                Price = wine.Price,
            };
        }

        public static GetGiftResponse ToResponseTeddy(this Teddy teddy)
        {
            return new GetGiftResponse
            {
                Id = teddy.Id,
                Name = teddy.Name,
                ImageUrl = teddy.ImageUrl,
                Price = teddy.Price,
            };
        }

        public static GetGiftResponse ToResponseChocolate(this Chocolate chocolate)
        {
            return new GetGiftResponse
            {
                Id = chocolate.Id,
                Name = chocolate.Name,
                ImageUrl = chocolate.ImageUrl,
                Price = chocolate.Price,
            };
        }
    }
}
