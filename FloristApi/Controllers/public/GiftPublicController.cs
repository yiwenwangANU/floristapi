using FloristApi.Controllers.baseController;
using FloristApi.Models.Entities;
using FloristApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace FloristApi.Controllers.@public
{
    [Route("api/public/wine")]
    public sealed class WinePublicController : GiftPublicBaseController<Wine>
    {
        public WinePublicController(IGiftReadService<Wine> giftReadService)
            : base(giftReadService)
        {
        }
    }
    [Route("api/public/chocolate")]
    public sealed class ChocolatePublicController : GiftPublicBaseController<Chocolate>
    {
        public ChocolatePublicController(IGiftReadService<Chocolate> giftReadService)
            : base(giftReadService)
        {
        }
    }
    [Route("api/public/teddy")]
    public sealed class TeddyPublicController : GiftPublicBaseController<Teddy>
    {
        public TeddyPublicController(IGiftReadService<Teddy> giftReadService)
            : base(giftReadService)
        {
        }
    }
}
