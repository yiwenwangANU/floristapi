namespace FloristApi.Integrations.Stripe
{
    public class StripeModel
    {
        public string SecretKey { get; set; } = default!;
        public string PublishableKey { get; set; } = default!;
    }
}
