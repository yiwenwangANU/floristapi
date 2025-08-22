using FloristApi.Models.Dtos.admin;
using FloristApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FloristApi.Controllers.admin
{
    [Route("api/admin/flower")]
    [ApiController]
    public class FlowerAdminController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IFlowerWriteService _flowerWriteService;
        public FlowerAdminController(UserManager<IdentityUser> userManager, IFlowerWriteService flowerWriteService)
        {
            _userManager = userManager;
            _flowerWriteService = flowerWriteService;
        }

        [HttpPost("createFlower")]
        public async Task<IActionResult> CreateFlower([FromBody] CreateFlowerDto dto, CancellationToken ct)
        {
            var response = await _flowerWriteService.CreateFlower(dto, ct);
            return Ok(response);
        }
        [HttpPost("editFlower")]
        public async Task<IActionResult> EditFlower(int id, [FromBody] CreateFlowerDto dto, CancellationToken ct)
        {
            var response = await _flowerWriteService.EditFlower(id, dto, ct);
            return Ok(response);
        }
        [HttpDelete("deleteFlower")]
        public async Task<IActionResult> DeleteFlower(int id)
        {
            await _flowerWriteService.DeleteFlower(id);
            return Ok();
        }
    }
}
