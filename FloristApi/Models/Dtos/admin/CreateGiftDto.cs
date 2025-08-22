using System.ComponentModel.DataAnnotations;

namespace FloristApi.Models.Dtos.admin
{
    public class CreateGiftDto
    {
        [Required(ErrorMessage = "Name is required.")]
        [StringLength(30, ErrorMessage = "Name can't exceed 30 characters.")]
        public required string Name { get; set; }
        [Required(ErrorMessage = "Price is required.")]
        [Range(1, 10000, ErrorMessage = "Price must be between $1 and $10,000.")]
        public required int Price { get; set; }
        [Required(ErrorMessage = "Image URL is required.")]
        [Url(ErrorMessage = "ImageUrl must be a valid URL.")]
        public required string ImageUrl { get; set; } 
    }
}
