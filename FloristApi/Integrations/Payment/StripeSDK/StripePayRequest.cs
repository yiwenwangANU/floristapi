namespace FloristApi.Integrations.Payment.Stripe
{
    public class StripePayRequest
    {
        public List<StripeCartItems> Items { get; set; } = [];
    }
}
