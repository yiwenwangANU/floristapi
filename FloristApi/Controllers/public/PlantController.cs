using FloristApi.Models.Dtos.@public;
using FloristApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FloristApi.Controllers.@public
{
    [Route("api/public/[controller]")]
    [ApiController]
    public class PlantController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IPlantReadService _plantService;
        public PlantController(UserManager<IdentityUser> userManager, IPlantReadService plantService)
        {
            _userManager = userManager;
            _plantService = plantService;
        }

        [HttpGet("getPlants")]
        public async Task<IActionResult> GetPlants([FromQuery] GetPlantDto dto, CancellationToken ct)
        {
            var response = await _plantService.GetPlants(dto, ct);
            return Ok(response);
        }
        [HttpGet("getPlantById/{id}")]
        public async Task<IActionResult> GetPlantById(int id)
        {
            var response = await _plantService.GetPlantById(id);
            return Ok(response);
        }
    }
}
