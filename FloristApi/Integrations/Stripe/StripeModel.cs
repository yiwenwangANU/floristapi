namespace FloristApi.Integrations.Stripe
{
    public class StripeModel
    {
        public string SecretKey { get; set; } = default!;
        public string PublishableKey { get; set; } = default!;
        public string Domain { get; set; } = default!;
    }
}
