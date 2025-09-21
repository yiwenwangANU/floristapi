using FloristApi.Enums;
using System.ComponentModel.DataAnnotations;

namespace FloristApi.Models.Dtos.admin
{
    public class CreatePlantDto : IValidatableObject
    {
        [Required(ErrorMessage = "Name is required.")]
        [StringLength(100, ErrorMessage = "Name can't exceed 100 characters.")]
        public required string Name { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        [StringLength(1000, ErrorMessage = "Description can't exceed 1000 characters.")]
        public required string Description { get; set; }

        [Required(ErrorMessage = "Image URL is required.")]
        [Url(ErrorMessage = "ImageUrl must be a valid URL.")]
        public required string ImageUrl { get; set; }

        [Required(ErrorMessage = "Plant type is required.")]
        [EnumDataType(typeof(PlantTypes), ErrorMessage = "Invalid plant type.")]
        public required PlantTypes PlantType { get; set; }

        [Required(ErrorMessage = "Price is required.")]
        [Range(1, 10000, ErrorMessage = "Price must be between $1 and $10,000.")]
        public required int Price { get; set; }
        public int? Discount { get; set; }
        public bool? isPopular { get; set; } = false;

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            // Only validate discount if it has a value
            if (Discount.HasValue)
            {
                if (Discount.Value < 0)
                {
                    yield return new ValidationResult(
                        "Discount must be greater than 0 when provided",
                        new[] { nameof(Discount) });
                }

                if (Discount.Value >= Price)
                {
                    yield return new ValidationResult(
                        "Discount must be smaller than the price",
                        new[] { nameof(Discount) });
                }
            }
        }
    }
}
