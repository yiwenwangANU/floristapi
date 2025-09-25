using FloristApi.Integrations.Stripe;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Stripe;
using Stripe.Checkout;

namespace FloristApi.Controllers.@public
{
    public class StripeController: ControllerBase
    {
        private readonly StripeModel _model;
        private readonly TokenService _tokenService;
        private readonly CustomerService _customerService;
        private readonly ChargeService _chargeService;
        private readonly ProductService _productService;

        public StripeController(IOptions<StripeModel> model,
            TokenService tokenService,
            CustomerService customerService,
            ChargeService chargeService,
            ProductService productService)
        {
            _model = model.Value;
            _tokenService = tokenService;
            _customerService = customerService;
            _chargeService = chargeService;
            _productService = productService;
        }
        [HttpPost("Pay")]
        public IActionResult Pay([FromBody] string priceId)
        {
            StripeConfiguration.ApiKey = _model.SecretKey;
            var options = new SessionCreateOptions
            {
                LineItems = new List<SessionLineItemOptions>
                {
                  new SessionLineItemOptions
                  {
                    Price = priceId,
                    Quantity = 1,
                  },
                },
                Mode = "payment",
                SuccessUrl = _model.Domain + "/checkout/success",
                CancelUrl = _model.Domain + "/checkout/cancel",
            };
            var service = new SessionService();
            Session session = service.Create(options);
            return Ok(session.Url);
        }
    }
}
