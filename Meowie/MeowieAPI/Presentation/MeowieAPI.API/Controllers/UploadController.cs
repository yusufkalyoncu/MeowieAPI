using MeowieAPI.Application.Abstractions.Storage;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MeowieAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadController : ControllerBase
    {
        readonly IStorageService _storageService;

        public UploadController(IStorageService storageService)
        {
            _storageService = storageService;
        }
        [HttpPost()]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            await _storageService.UploadAsync("username","resource/profile-pictures", file);
            return Ok();
        }
    }
}
