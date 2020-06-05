using System;
using DVDRentalAPI.Models;
using DVDRentalAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DVDRentalAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {
        private readonly IUserService _userService;
        private readonly ILogger<AuthController> _logger;

        public AuthController(IUserService userService, ILogger<AuthController> logger, IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [AllowAnonymous]
        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BadRequestObjectResult), StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public IActionResult Login([FromBody] AuthenticationModel model)
        {
            UserModel userModel = null;
            try
            {
                userModel = _userService.Authenticate(model.UserName, model.Password);

                if (userModel == null)
                    return BadRequest(new { message = "Invalid Login. UserName or password is incorrect" });
            }
            catch (Exception ex)
            {
                _logger.LogError(GetExceptionMessage(ex));
            }
            return Ok(userModel);
        }

        [AllowAnonymous]
        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BadRequestObjectResult), StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public IActionResult Register([FromBody] UserModel model)
        {
            bool result = false;

            try
            {
                result = _userService.Register(model);

                if (result == false)
                    return BadRequest(new { message = "Problem occured during registration" });
            }
            catch (Exception ex)
            {
                _logger.LogError(GetExceptionMessage(ex));
            }

            return Ok(result);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetAll()
        {
            var users = _userService.GetAll();
            return Ok(users);
        }
    }
}
