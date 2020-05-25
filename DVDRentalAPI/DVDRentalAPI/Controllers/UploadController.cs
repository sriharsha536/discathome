using System.Threading.Tasks;
using DVDRentalAPI.Models;
using DVDRentalAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace DVDRentalAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UploadController : Controller
    {
        private readonly IUploadService _uploadService;
        public UploadController(IUploadService uploadService)
        {
            _uploadService = uploadService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BadRequestObjectResult), StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> UploadMovie([FromBody] UploadModel uploadModel)
        {
            var logFilePath = await _uploadService.UploadMovieFileAsync(uploadModel);

            if (string.IsNullOrEmpty(logFilePath) || string.IsNullOrWhiteSpace(logFilePath))
                return BadRequest(new { message = "Problem occured during upload" });

            return Ok(logFilePath);
        }
    }
}
