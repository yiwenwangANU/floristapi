using FloristApi.Models.Dtos;
using FloristApi.Models.Dtos.@public;
using FloristApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;


namespace FloristApi.Controllers.@public
{
    [Route("api/public/[controller]")]
    [ApiController]
    public class FlowerController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IFlowerReadService _flowerService;
        public FlowerController(UserManager<IdentityUser> userManager, IFlowerReadService flowerService)
        {
            _userManager = userManager;
            _flowerService = flowerService;
        }
        
        [HttpGet("getFlowers")]
        public async Task<IActionResult> GetFlowers([FromQuery] GetFlowerDto dto, CancellationToken ct)
        {
            var response = await _flowerService.GetFlowers(dto, ct);
            return Ok(response);
        }
        [HttpGet("getFlowerById/{id}")]
        public async Task<IActionResult> GetFlowerById(int id)
        {
            var response = await _flowerService.GetFlowerById(id);
            return Ok(response);
        }
    }

}
