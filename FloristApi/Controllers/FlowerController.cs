using FloristApi.Models.Dtos;
using FloristApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;


namespace FloristApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlowerController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IFlowerService _flowerService;
        public FlowerController(UserManager<IdentityUser> userManager, IFlowerService flowerService)
        {
            _userManager = userManager;
            _flowerService = flowerService;
        }
        [HttpPost("createFlower")]
        public async Task<IActionResult> CreateFlower([FromBody]CreateFlowerDto dto)
        {
            var response = await _flowerService.CreateFlower(dto);
            return Ok(response);
        }
        [HttpGet("getFlowers")]
        public async Task<IActionResult> GetFlowers()
        {
            var response = await _flowerService.GetFlowers();
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
