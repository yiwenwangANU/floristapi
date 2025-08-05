using FloristApi.Enums;
using System.ComponentModel.DataAnnotations;

namespace FloristApi.Models.Dtos
{
    public class CreateFlowerDto : IValidatableObject
    {
        [Required(ErrorMessage = "Name is required.")]
        [StringLength(30, ErrorMessage = "Name can't exceed 30 characters.")]
        public required string Name { get; set; }
        [Required(ErrorMessage = "Description is required.")]
        [StringLength(500, ErrorMessage = "Description can't exceed 500 characters.")]
        public required string Description { get; set; }
        [Required(ErrorMessage = "Image URL is required.")]
        [Url(ErrorMessage = "ImageUrl must be a valid URL.")]
        public required string ImageUrl { get; set; }
        [Required(ErrorMessage = "Price is required.")]
        [Range(1, 10000, ErrorMessage = "Price must be between $1 and $10,000.")]
        public required int Price { get; set; }
        [Required(ErrorMessage = "Product type is required.")]
        [EnumDataType(typeof(ProductTypes), ErrorMessage = "Invalid product type.")]
        public required ProductTypes ProductType { get; set; }
        public int? Discount { get; set; } = 0;

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            // Only validate discount if it has a value
            if (Discount.HasValue)
            {
                if (Discount.Value <= 0)
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
