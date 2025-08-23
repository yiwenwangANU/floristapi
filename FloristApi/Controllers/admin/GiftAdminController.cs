using FloristApi.Controllers.baseController;
using FloristApi.Models.Entities;
using FloristApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FloristApi.Controllers.admin
{
    [Route("api/admin/wine")]
    public sealed class WineAdminController : GiftAdminBaseController<Wine>
    {
        public WineAdminController(IGiftReadService<Wine> giftReadService, IGiftWriteService<Wine> giftWriteService)
            : base(giftReadService, giftWriteService)
        {
        }
    }
    [Route("api/admin/chocolate")]
    public sealed class ChocolateAdminController : GiftAdminBaseController<Chocolate>
    {
        public ChocolateAdminController(IGiftReadService<Chocolate> giftReadService, IGiftWriteService<Chocolate> giftWriteService)
            : base(giftReadService, giftWriteService)
        {
        }
    }
    [Route("api/admin/teddy")]
    public sealed class TeddyAdminController : GiftAdminBaseController<Teddy>
    {
        public TeddyAdminController(IGiftReadService<Teddy> giftReadService, IGiftWriteService<Teddy> giftWriteService)
            : base(giftReadService, giftWriteService)
        {
        }

    }
}