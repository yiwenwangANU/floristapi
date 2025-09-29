namespace FloristApi.Integrations.Payment
{
    public class StripeCartItems
    {
        public string PriceId { get; set; } = default!;
        public int Quantity { get; set; } = 1;
    }
}
