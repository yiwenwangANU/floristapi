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

        [Required(ErrorMessage = "Product type is required.")]
        [EnumDataType(typeof(ProductTypes), ErrorMessage = "Invalid product type.")]
        public required ProductTypes ProductType { get; set; }

        [Required(ErrorMessage = "Color is required.")]
        [EnumDataType(typeof(ColorTypes), ErrorMessage = "Invalid color type.")]
        public required ColorTypes Color { get; set; }

        [Required(ErrorMessage = "Occasion is required.")]
        [EnumDataType(typeof(OccasionTypes), ErrorMessage = "Invalid occasion type.")]
        public required OccasionTypes Occasion { get; set; }

        public List<int> FlowerTypeIds { get; set; } = new List<int>();

        [Required(ErrorMessage = "Price is required.")]
        [Range(1, 10000, ErrorMessage = "Price must be between $1 and $10,000.")]
        public required int Price { get; set; }
        public int? Discount { get; set; }
        public bool? isPopular { get; set; } = false;

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (FlowerTypeIds == null || FlowerTypeIds.Count == 0)
                yield return new ValidationResult("Select at least one flower type.", new[] { nameof(FlowerTypeIds) });

            if (FlowerTypeIds.Count != FlowerTypeIds.Distinct().Count())
                yield return new ValidationResult("Duplicate flower types are not allowed.", new[] { nameof(FlowerTypeIds) });
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
