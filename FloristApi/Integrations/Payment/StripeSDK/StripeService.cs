using FloristApi.Models.Entities;
using SdkStripe = global::Stripe;
namespace FloristApi.Integrations.Payment.Stripe
{
    public class StripeService: IStripeService
    {
        private readonly SdkStripe.ProductService _products;
        public StripeService(SdkStripe.ProductService products) => _products = products;
        public async Task<(string productId, string priceId)> CreateStripeProduct(Flower flower, CancellationToken ct)
        {
            var productOptions = new SdkStripe.ProductCreateOptions
            {
                Name = flower.Name,
                Images = new List<string> { flower.ImageUrl },
                DefaultPriceData = new SdkStripe.ProductDefaultPriceDataOptions
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
