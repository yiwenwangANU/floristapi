using FloristApi.Models.Dtos.admin;
using FloristApi.Models.Entities;
using FloristApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FloristApi.Controllers.baseController
{
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class GiftAdminBaseController<T> : ControllerBase where T : class, IGiftEntity
    {
        private readonly IGiftReadService<T> _giftReadService;
        private readonly IGiftWriteService<T> _giftWriteService;
        public GiftAdminBaseController(IGiftReadService<T> giftReadService, IGiftWriteService<T> giftWriteService)
        {
            _giftReadService = giftReadService;
            _giftWriteService = giftWriteService;
        }
        [HttpGet]
        public async Task<IActionResult> GetGifts()
        {
            var gifts = await _giftReadService.GetAllGifts();
            return Ok(gifts);
        }
        [HttpPost]
        public async Task<IActionResult> CreateGift([FromBody] CreateGiftDto dto, CancellationToken ct)
        {
            var response = await _giftWriteService.CreateGift(dto, ct);
            return Ok(response);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateGift(int id, [FromBody] CreateGiftDto dto, CancellationToken ct)
        {
            var response = await _giftWriteService.UpdateGift(id, dto, ct);
            return Ok(response);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteGift(int id)
        {
            await _giftWriteService.DeleteGift(id);
            return NoContent();
        }
    }
}
