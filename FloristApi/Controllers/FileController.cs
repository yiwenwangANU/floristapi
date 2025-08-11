using FloristApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FloristApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private static readonly string[] Allowed = { "image/png", "image/jpeg", "image/webp" };
        private const long MaxBytes = 5 * 1024 * 1024;

        private readonly IBlobService _blobService;

        public FileController(IBlobService blobservice)
        {
            _blobService = blobservice;
        }

        [HttpPost("upload-image")]
        [Consumes("multipart/form-data")]
        [RequestSizeLimit(MaxBytes)] 
        public async Task<IActionResult> UploadImage(IFormFile file, CancellationToken ct)
        {
            if (file is null || file.Length == 0) return BadRequest("No file.");
            if (!Allowed.Contains(file.ContentType)) return BadRequest("Only PNG/JPEG/WEBP.");
            if (file.Length > MaxBytes) return BadRequest("Max 5MB.");

            await using var stream = file.OpenReadStream();
            var url = await _blobService.UploadAsync(stream, file.FileName, file.ContentType, ct);

            return Ok(new { url });
        }
    }
}
