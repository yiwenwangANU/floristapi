using FloristApi.Models.Entities;
using Stripe;
namespace FloristApi.Integrations.Payment
{
    public class StripeService: IStripeService
    {
        private readonly ProductService _products;
        public StripeService(ProductService products) => _products = products;
        public async Task<(string productId, string priceId)> CreateStripeProduct(Flower flower, CancellationToken ct)
        {
            var productOptions = new ProductCreateOptions
            {
                Name = flower.Name,
                Images = new List<string> { flower.ImageUrl },
                DefaultPriceData = new ProductDefaultPriceDataOptions
                {
                    UnitAmount = flower.Price * 100,
                    Currency = "aud",
                },
            };

            var product = await _products.CreateAsync(productOptions);
            return (product.Id, product.DefaultPriceId);
        }
    }
}
