namespace FloristApi.Integrations.Payment.Stripe
{
    public class StripeCartItems
    {
        public string PriceId { get; set; } = default!;
        public int Quantity { get; set; } = 1;
    }
}
