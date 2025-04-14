using Microsoft.AspNetCore.Mvc;
using Skyvibe_Webapplikation1.Services.Interfaces;
using SkyVibe_Webapplikation1.DTOs;
using SkyVibe_Webapplikation1.Services.Interfaces;

namespace SkyVibe_Webapplikation1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _service;

        public AuthController(IAuthService service)
        {
            _service = service;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegisterDTO dto)
        {
            var token = await _service.RegisterAsync(dto);
            return Ok(token);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginDTO dto)
        {
            var token = await _service.LoginAsync(dto);
            return Ok(token);
        }
    }
}
