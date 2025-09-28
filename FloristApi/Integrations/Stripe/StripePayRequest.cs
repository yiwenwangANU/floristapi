namespace FloristApi.Integrations.Stripe
{
    public class StripePayRequest
    {
        public List<StripeCartItems> Items { get; set; } = [];
    }
}
