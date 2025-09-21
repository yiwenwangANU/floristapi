using FloristApi.Models.Dtos.admin;
using FloristApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FloristApi.Controllers.admin
{
    [Route("api/admin/plant")]
    [ApiController]
    public class PlantAdminController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IPlantWriteService _plantWriteService;
        public PlantAdminController(UserManager<IdentityUser> userManager, IPlantWriteService plantWriteService)
        {
            _userManager = userManager;
            _plantWriteService = plantWriteService;
        }
        [HttpPost("createPlant")]
        public async Task<IActionResult> CreatePlant([FromBody] CreatePlantDto dto, CancellationToken ct)
        {
            var response = await _plantWriteService.CreatePlant(dto, ct);
            return Ok(response);
        }
        [HttpPut("updatePlant")]
        public async Task<IActionResult> UpdatePlant(int id, [FromBody] CreatePlantDto dto, CancellationToken ct)
        {
            var response = await _plantWriteService.UpdatePlant(id, dto, ct);
            return Ok(response);
        }
        [HttpDelete("deletePlant")]
        public async Task<IActionResult> DeletePlant(int id)
        {
            await _plantWriteService.DeletePlant(id);
            return Ok();
        }
    }
}
