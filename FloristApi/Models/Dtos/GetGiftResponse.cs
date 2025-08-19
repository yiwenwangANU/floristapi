using FloristApi.Enums;

namespace FloristApi.Models.Dtos
{
    public class GetGiftResponse
    {
        public int Id { get; set; } = 0;
        public string Name { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public int Price { get; set; }
    }
}
