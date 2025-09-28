using FloristApi.Integrations.Stripe;
using FloristApi.Models.Dtos.admin;
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
        private readonly PriceService _priceService;

        public StripeController(IOptions<StripeModel> model,
            TokenService tokenService,
            CustomerService customerService,
            ChargeService chargeService,
            ProductService productService,
            PriceService priceService)
        {
            _model = model.Value;
            _tokenService = tokenService;
            _customerService = customerService;
            _chargeService = chargeService;
            _productService = productService;
            _priceService = priceService;
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

        [HttpPost("CreateCustomer")]
        public async Task<dynamic> CreateCustomer([FromBody] StripeCustomer customerInfo)
        {
            StripeConfiguration.ApiKey = _model.SecretKey;

            var customerOptions = new CustomerCreateOptions
            {
                Email = customerInfo.Email,
                Name = customerInfo.Name
            };

            var customer = await _customerService.CreateAsync(customerOptions);
            return new { customer };
        }

        [HttpPost("GetAllProducts")]
        public IActionResult GetAllProducts() 
        {
            StripeConfiguration.ApiKey = _model.SecretKey;
            var options = new ProductListOptions { Expand = new List<string>() { "data.default_price" } };
            var products = _productService.List(options);
            return Ok(products); 
        }

        [HttpPost("CreateStripeProduct")]
        public async Task<IActionResult> CreateProduct([FromBody] CreateFlowerDto dto)
        {
            StripeConfiguration.ApiKey = _model.SecretKey;
            var productOptions = new ProductCreateOptions
            {
                Name = dto.Name,
                Description = dto.Description,
                Images = new List<string> { dto.ImageUrl },
                DefaultPriceData = new ProductDefaultPriceDataOptions
                {
                    UnitAmount = dto.Price,
                    Currency = "aud",
                },
            };

            var product = _productService.CreateAsync(productOptions);
            return Ok();
        }
    }
}
