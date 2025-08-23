using FloristApi.Models.Entities;
using FloristApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FloristApi.Controllers.baseController
{
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = true)] // hide the base from Swagger
    public class GiftPublicBaseController<T> : ControllerBase where T : class, IGiftEntity
    {
        private readonly IGiftReadService<T> _giftReadService;
        public GiftPublicBaseController(IGiftReadService<T> giftReadService)
        {
            _giftReadService = giftReadService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllGifts()
        {
            var gifts = await _giftReadService.GetAllGifts();
            return Ok(gifts);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetGiftById(int id)
        {
            var gift = await _giftReadService.GetGiftById(id);
            return Ok(gift);       
        }
    }
}
