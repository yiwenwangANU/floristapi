using Microsoft.AspNetCore.Mvc;

namespace FloristApi.Controllers.@public
{
    public class StripeController: ControllerBase
    {
        [HttpPost("Pay")]
        public IActionResult Pay([FromBody] string priceId)
        {

        }
    }
}
