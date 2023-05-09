using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MeowieAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly string _imageFolder;

        public ImagesController(IWebHostEnvironment env)
        {
            _imageFolder = Path.Combine(env.WebRootPath, "resource", "profile-pictures");
        }

        [HttpGet("{fileName}")]
        public IActionResult GetImage(string fileName)
        {
            var imagePath = Path.Combine(_imageFolder, fileName);

            if (!System.IO.File.Exists(imagePath))
                return NotFound();

            var imageFileStream = System.IO.File.OpenRead(imagePath);

            return new FileStreamResult(imageFileStream, "image/jpeg");
        }
    }
}
