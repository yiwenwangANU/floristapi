using FloristApi.Models.Entities;

namespace FloristApi.Integrations.Payment
{
    public interface IStripeService
    {
        Task<(string productId, string priceId)> CreateStripeProduct(Flower flower, CancellationToken ct);
    }
}
