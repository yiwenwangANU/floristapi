using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stripe;

namespace FloristApi.Controllers.@public
{
    [Route("api/webhooks/stripe")]
    [ApiController]
    public class StripeWebhooks : ControllerBase
    {
        private readonly string _endpointSecret;
        private readonly ILogger<StripeWebhooks> _logger;
        public StripeWebhooks(IConfiguration configuration, ILogger<StripeWebhooks> logger)
        {
            _endpointSecret = configuration["Stripe:WebhookSecret"] ?? string.Empty;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Index()
        {
            var json = await new StreamReader(HttpContext.Request.Body).ReadToEndAsync();
            try
            {
                var stripeEvent = EventUtility.ParseEvent(json);
                var signatureHeader = Request.Headers["Stripe-Signature"];

                if (string.IsNullOrEmpty(_endpointSecret))
                {
                    _logger.LogError("Stripe webhook secret is not configured. Set 'Stripe:WebhookSecret'.");
                    return StatusCode(500);
                }
                stripeEvent = EventUtility.ConstructEvent(json, signatureHeader, _endpointSecret);

                // Handle the event
                // If on SDK version < 46, use class Events instead of EventTypes
                if (stripeEvent.Type == EventTypes.PaymentIntentSucceeded)
                {
                    var paymentIntent = stripeEvent.Data.Object as PaymentIntent;
                    if (paymentIntent != null)
                    {
                        _logger.LogInformation(
                            "PaymentIntent succeeded: {PaymentIntentId}, amount={Amount}, currency={Currency}",
                            paymentIntent.Id, paymentIntent.Amount, paymentIntent.Currency);
                        // TODO: handle success (update DB, fulfill order, etc.)
                    }
                    // Then define and call a method to handle the successful payment intent.
                    // handlePaymentIntentSucceeded(paymentIntent);
                }
                else if (stripeEvent.Type == EventTypes.PaymentMethodAttached)
                {
                    var paymentMethod = stripeEvent.Data.Object as PaymentMethod;
                    // Then define and call a method to handle the successful attachment of a PaymentMethod.
                    // handlePaymentMethodAttached(paymentMethod);
                }
                // ... handle other event types
                else
                {
                    // Unexpected event type
                    Console.WriteLine("Unhandled event type: {0}", stripeEvent.Type);
                }
                return Ok();
            }
            catch (StripeException e)
            {
                return BadRequest();
            }
        }
    }
}
