namespace FloristApi.Integrations.Payment
{
    public class StripePayRequest
    {
        public List<StripeCartItems> Items { get; set; } = [];
    }
}
